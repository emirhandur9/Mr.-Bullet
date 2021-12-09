using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{



    public void Death()
    {
        gameObject.tag = "Untagged";
        GameManager.instance.CheckEnemyCount();

        Rigidbody2D[] rbs = FindObjectsOfType<Rigidbody2D>();
        foreach (var item in rbs)
        {
            item.constraints = RigidbodyConstraints2D.None;
        }
    }

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
    }

    
}
