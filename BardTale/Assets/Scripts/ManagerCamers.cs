using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ManagerCamers : MonoBehaviour
{
    [SerializeField] private CinemachineMixingCamera cameraMix;
    [SerializeField] private GameObject player;
    [SerializeField] private float distance0;
    [SerializeField] private float distance1;
    [SerializeField] private GameObject camera0;
    [SerializeField] private GameObject camera1;
    [SerializeField] private bool isNorm;
    public void UpdateCameraMix(int number)
    {
        switch (number)
        {
            case 0:
                cameraMix.m_Weight0 = 1;
                cameraMix.m_Weight1 = 0;
                break;
            case 1:
                cameraMix.m_Weight1 = 1;
                cameraMix.m_Weight0 = 0;
                break;
        }
    }

    private void Update()
    {
        distance0 = Vector3.Distance(player.transform.position, camera0.transform.position);
        distance1 = Vector3.Distance(player.transform.position, camera1.transform.position);

        if (isNorm)
        {
            if (distance0 > distance1)
            {
                UpdateCameraMix(0);
            }
            else
            {
                UpdateCameraMix(1);
            }
        }
        if (!isNorm) 
        {
            if (distance0 > distance1)
            {
                UpdateCameraMix(1);
            }
            else
            {
                UpdateCameraMix(0);
            }
        }
    }


}
