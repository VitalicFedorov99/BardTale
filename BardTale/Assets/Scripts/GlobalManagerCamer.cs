using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;
public class GlobalManagerCamer : MonoBehaviour
{
    [SerializeField] private List<GameObject> placeCamers;
    [SerializeField] private List<float> distances;
    [SerializeField] private float min;
    [SerializeField] private int currentCameraId;
    [SerializeField] private GameObject player;
    [SerializeField] private List<CinemachineMixingCamera> camers;
    private void Start()
    {
        distances = new List<float>();
        for (int i = 0; i < placeCamers.Count; i++)
        {
            distances.Add(0);
        }
        ChooseCamera(0);
    }
  


    public void SetIncludeCameraId(int id) 
    {
        ChooseCamera(id);
    }
    private void ChooseCamera(int id)
    {
        for (int i = 0; i < camers.Count; i++)
        {
            if (id != i)
            {
                Debug.Log(" ne popal");
                camers[i].m_Priority = -1;
                camers[i].gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("popal");
                camers[i].m_Priority = 1;
                camers[i].gameObject.SetActive(true);
            }
        }
    }


    private void SetupFollow() 
    {
        
    }
}
