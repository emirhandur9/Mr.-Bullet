using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioClip boxHit, plankHit, groundHit, explodeHit; 

    public GameObject bloodParticle;
    public GameObject woodParticle;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            ParticleGenerator(bloodParticle, collision);
        }
        else if (collision.transform.CompareTag("Box"))
        {
            SoundManager.instance.PlaySoundFX(boxHit, 1f);
            ParticleGenerator(woodParticle, collision);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.transform.CompareTag("Ground"))
        {
            SoundManager.instance.PlaySoundFX(groundHit, .3f);
        }
        else if (collision.transform.CompareTag("Plank"))
        {
            SoundManager.instance.PlaySoundFX(plankHit, 1f);
        }
        else if (collision.transform.CompareTag("Tnt"))
        {
            SoundManager.instance.PlaySoundFX(explodeHit, 1f);
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
