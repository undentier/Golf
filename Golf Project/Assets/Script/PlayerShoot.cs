using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float force;
    public Rigidbody playerRb;
    public Transform partToRotate;
    public Transform mainCam;
    public GameObject aimGraph;

    private float mouseCord;

    private void Start()
    {
        aimGraph.SetActive(false);
    }
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            //playerRb.AddForce(Vector3.forward * force);
            aimGraph.SetActive(true);
            AimShoot();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            aimGraph.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerRb.AddForce(Vector3.up * force / 3f);
        }

    }

    void AimShoot()
    {
        partToRotate.transform.localEulerAngles = new Vector3(0f, mainCam.localEulerAngles.y, 0f);
    }
}
