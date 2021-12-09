using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tnt : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float radius = 5;
    public float power = 10;

   
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.transform.CompareTag("Bullet"))
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            //TODO: CAMERA SHAKE
            Explode();
            Destroy(gameObject);
        }
    }

    private void Explode()
    {
        Vector2 explosionPos = transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius);

        foreach (var hit in colliders)
        {
            if(hit.GetComponent<Rigidbody2D>() != null)
            {
                Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
                var explodeDir = rb.position - explosionPos;

                if(hit.GetComponent<Enemy>() != null)
                {
                    hit.GetComponent<Enemy>().Death();
                }

                rb.AddForce(power * explodeDir, ForceMode2D.Impulse);
            }

            if (hit.CompareTag("Enemy"))
                hit.tag = "Untagged";
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
