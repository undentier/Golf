using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float force;
    public Rigidbody playerRb;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.forward * force);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerRb.AddForce(Vector3.up * force / 3f);
        }
    }
}
