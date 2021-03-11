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
            aimGraph.SetActive(true);
            AimShoot();

            if (Input.GetAxis("Mouse Y") > 0)
            {
                Debug.Log("je rentre");
                force += 10f;
            }

            if (Input.GetAxis("Mouse Y") < 0 && force > 0)
            {
                force -= 10f;
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            aimGraph.SetActive(false);
            if (force > 0)
            {
                playerRb.AddForce(partToRotate.right * force);
                force = 0;
            }
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
