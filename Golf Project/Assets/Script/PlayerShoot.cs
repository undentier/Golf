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

    [Header ("UI shoot")]
    public Material material;
    public Gradient gradient;
    public LineRenderer aimLine;
    public Image fillImage;

    [HideInInspector]
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

        SetColor(power);

        fillImage.fillAmount = power / maxPower;
    }

    void AimShoot()
    {
        partToRotate.transform.localEulerAngles = new Vector3(0f, mainCam.localEulerAngles.y, 0f);
        aimLine.SetPosition(0, new Vector3(power / maxPower * 10f, 0f, 0f));
    }

    void ShootSysteme()
    {
        if (Input.GetButton("Shoot"))
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
        if (Input.GetButtonUp("Shoot"))
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

    void SetColor(float power)
    {
        material.color = gradient.Evaluate((power / maxPower));
    }
}
