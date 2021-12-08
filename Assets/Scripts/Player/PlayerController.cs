using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotateSpeed = 100;
    public float bulletSpeed = 100;

    private Transform handPos;
    private Transform firePos1;
    private Transform firePos2;

    private LineRenderer lineRenderer;

    public GameObject bullet;

    private Camera cam;

    private void Awake()
    {
        handPos = GameObject.Find("LeftArm").transform;
        firePos1 = GameObject.Find("FirePos1").transform;
        firePos2 = GameObject.Find("FirePos2").transform;

        lineRenderer = GameObject.Find("Gun").GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Aim();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Shoot();
        }
    }


    private void Aim()
    {
        var dir = Input.mousePosition - cam.WorldToScreenPoint(handPos.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
        handPos.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, firePos1.position);
        lineRenderer.SetPosition(1, firePos2.position);

    }

    private void Shoot()
    {
        lineRenderer.enabled = false;
    }
}