using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MouseScrolling : MonoBehaviour
{
    public CinemachineFreeLook playerCam;
    

    private void Start()
    {
        
    }

    void Update()
    {

        Zoom();
    }

    void Zoom()
    {
        if (Input.mouseScrollDelta.y > 0 && playerCam.m_Orbits[2].m_Radius > 0.5f && playerCam.m_Orbits[0].m_Radius > 0.5f)
        {
            playerCam.m_Orbits[0].m_Radius -= 0.2f;
            playerCam.m_Orbits[0].m_Height -= 0.15f;

            playerCam.m_Orbits[1].m_Radius -= 0.2f;
            playerCam.m_Orbits[2].m_Radius -= 0.2f;
        }
        if (Input.mouseScrollDelta.y < 0 && playerCam.m_Orbits[0].m_Radius < 7f)
        {
            playerCam.m_Orbits[0].m_Radius += 0.2f;
            playerCam.m_Orbits[0].m_Height += 0.15f;

            playerCam.m_Orbits[1].m_Radius += 0.2f;
            playerCam.m_Orbits[2].m_Radius += 0.2f;
        }
    }
}
