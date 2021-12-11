using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public AudioClip death;

    private void OnTriggerEnter2D(Collider2D target)
    {
        Vector2 direction = transform.position - target.transform.position;

        if (target.CompareTag("Bullet"))
        {
            Death();

            GetComponent<Rigidbody2D>().AddForce(new Vector2((direction.x > 0 ? 1 : -1) * 3, direction.y > 0 ? .3f : -.3f), ForceMode2D.Impulse);
        }

        if (target.CompareTag("Plank") || target.CompareTag("BoxPlank"))
        {
            if(target.GetComponent<Rigidbody2D>().velocity.magnitude > .5f)
            {
                Death();
            }
        }

        if(target.CompareTag("Ground") || target.CompareTag("Untagged"))
        {
            if (GetComponent<Rigidbody2D>().velocity.magnitude > 2)
                Death();
        }

        if (target.CompareTag("EnemyItself"))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2((direction.x > 0 ? 1 : -1) * 15, 0), ForceMode2D.Impulse);
        }

    }

    
    public void Death()
    {
        gameObject.tag = "Untagged";
        GameManager.instance.CheckEnemyCount();

        //Rigidbody2D[] rbs = FindObjectsOfType<Rigidbody2D>();
        transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        foreach (Rigidbody2D rb in FindChildRB(transform))
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
        SoundManager.instance.PlaySoundFX(death, .75f);
    }

    private List<Rigidbody2D> FindChildRB(Transform transform)
    {
        List<Rigidbody2D> rigidbody2Ds = new List<Rigidbody2D>();

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform childUp = transform.GetChild(i);

            if (childUp.childCount == 0) //child'i olmayanlar
            {

                if (childUp.GetComponent<Rigidbody2D>() != null)
                {
                    rigidbody2Ds.Add(childUp.GetComponent<Rigidbody2D>());
                }
            }
            else //child'i olanlar.
            {
                if (childUp.GetComponent<Rigidbody2D>() != null)
                {
                    rigidbody2Ds.Add(childUp.GetComponent<Rigidbody2D>());
                }

                for (int j = 0; j < childUp.childCount; j++)
                {
                    if (childUp.GetChild(j).GetComponent<Rigidbody2D>() != null)
                    {
                        rigidbody2Ds.Add(childUp.GetChild(j).GetComponent<Rigidbody2D>());
                    }
                }
            }
        }
        Debug.Log(rigidbody2Ds.Count);
        return rigidbody2Ds;
    }
}
