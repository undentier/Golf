using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    #region Variable
    public float maxPower;
    public Rigidbody playerRb;
    public Transform partToRotate;
    public Transform mainCam;
    public GameObject aimGraph;

    public Image fillImage;

    public bool isMoving;
    private float power;
    #endregion variable

    private void Start()
    {
        aimGraph.SetActive(false);
    }
    void Update()
    {
        VelocityDetection();

        if (isMoving == false)
        {
            ShootSysteme();
        }

        fillImage.fillAmount = power / maxPower;
    }

    void AimShoot()
    {
        partToRotate.transform.localEulerAngles = new Vector3(0f, mainCam.localEulerAngles.y, 0f);
    }

    void ShootSysteme()
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
    }

    void VelocityDetection()
    {
        if (playerRb.velocity != Vector3.zero)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }
}
