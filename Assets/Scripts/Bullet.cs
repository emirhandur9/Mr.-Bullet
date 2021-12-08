using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject blood;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            Vector2 direction = transform.position - collision.transform.position;
            Quaternion rotation;


            if (direction.x > 0)
            {
                rotation = Quaternion.Euler(0, -90, 90);
            }
            else
            {
                rotation = Quaternion.Euler(0, -90, 90);
            }


            GameObject b = Instantiate(blood, transform.position, rotation);
        }
        

    }
}
