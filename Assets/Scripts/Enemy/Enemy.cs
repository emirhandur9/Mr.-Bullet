using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{



    private void Death()
    {
        gameObject.tag = "Untagged";

        Rigidbody2D[] rbs = FindObjectsOfType<Rigidbody2D>();
        foreach (var item in rbs)
        {
            item.constraints = RigidbodyConstraints2D.None;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        Vector2 direction = transform.position - coll.transform.position;

        if (coll.CompareTag("Bullet"))
        {
            Death();

            GetComponent<Rigidbody2D>().AddForce(new Vector2((direction.x > 0 ? 1 : -1) * 3, direction.y > 0 ? .3f : -.3f), ForceMode2D.Impulse);
        }
    }

    
}
