using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCamera : MonoBehaviour
{
    [SerializeField] private GlobalManagerCamer manager;
    [SerializeField] private int id;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ThirdPersonController player))
        {
            manager.SetIncludeCameraId(id);
            Debug.Log(id);
        }
    }
}
