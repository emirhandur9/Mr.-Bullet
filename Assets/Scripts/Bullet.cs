using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bloodParticle;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            ParticleGenerator(bloodParticle, collision);
        }
        else if (collision.transform.CompareTag("Box"))
        {
            Destroy(collision.gameObject);
        }
        

    }

    private void ParticleGenerator(GameObject particle, Collision2D collision)
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


        GameObject b = Instantiate(particle, transform.position, rotation);
    }
}
