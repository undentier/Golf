using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public float power;
    public float maxPower;
    public Rigidbody playerRb;
    public Transform partToRotate;
    public Transform mainCam;
    public GameObject aimGraph;

    public Image fillImage;

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

            if (Input.GetAxis("Mouse Y") > 0 && power < maxPower)
            {
                power += 30f;
            }

            if (Input.GetAxis("Mouse Y") < 0 && power > 0)
            {
                power -= 30f;
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            aimGraph.SetActive(false);
            if (power > 0)
            {
                playerRb.AddForce(partToRotate.right * power);
                power = 0;
            }
        }
        fillImage.fillAmount = power / maxPower;
    }

    void AimShoot()
    {
        partToRotate.transform.localEulerAngles = new Vector3(0f, mainCam.localEulerAngles.y, 0f);
    }
}
