using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float rotateSpeed = 100;
    public float bulletSpeed = 100;

    public int ammo;
    public int startingAmmo;
    public int blackBullets = 3;
    public int goldenBullets = 1;

    private Transform handPos;
    private Transform firePos1;
    private Transform firePos2;

    private LineRenderer lineRenderer;

    public GameObject bullet;

    private Camera cam;
    private GameObject crossHair;

    public AudioClip gunShoot;
    private void Awake()
    {
        crossHair = GameObject.Find("CrossHair");
        crossHair.SetActive(false);
        handPos = GameObject.Find("LeftArm").transform;
        firePos1 = GameObject.Find("FirePos1").transform;
        firePos2 = GameObject.Find("FirePos2").transform;

        lineRenderer = GameObject.Find("Gun").GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        cam = Camera.main;

        ammo = blackBullets + goldenBullets;
        startingAmmo = ammo;
    }

    private void Update()
    {
        if (!IsMouseOverUI())
        {
            if (Input.GetMouseButton(0))
            {
                Aim();
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (ammo > 0)
                    Shoot();
                else
                {
                    lineRenderer.enabled = false;
                    crossHair.SetActive(false);
                }
            }
        }
        
    }


    private void Aim()
    {
        crossHair.SetActive(true);
        var dir = Input.mousePosition - cam.WorldToScreenPoint(handPos.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
        handPos.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, firePos1.position);
        lineRenderer.SetPosition(1, firePos2.position);

        Vector3 crossHairPos = cam.ScreenToWorldPoint(Input.mousePosition);
        crossHairPos.z = transform.position.z;
        crossHair.transform.position = crossHairPos;

    }

    private void Shoot()
    {
        lineRenderer.enabled = false;
        crossHair.SetActive(false);


        GameObject bullet = Instantiate(this.bullet, firePos1.position, Quaternion.identity);

        if(transform.localScale.x > 0)
        {
            bullet.GetComponent<Rigidbody2D>().AddForce(firePos1.right * bulletSpeed, ForceMode2D.Impulse);
        }
        else
        {
            bullet.GetComponent<Rigidbody2D>().AddForce(-firePos1.right * bulletSpeed, ForceMode2D.Impulse);
        }
        ammo--;
        SoundManager.instance.PlaySoundFX(gunShoot, .3f);
        UIManager.instance.CheckBulletUI(ref blackBullets, ref goldenBullets);
        Destroy(bullet, 2);
    }

    bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
