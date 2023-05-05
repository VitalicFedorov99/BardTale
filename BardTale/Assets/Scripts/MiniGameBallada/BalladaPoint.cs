using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalladaPoint : MonoBehaviour
{

    [SerializeField] private ManagerBallada manager;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerMovement player)) 
        {
            manager.OpenChooseBalladsPanel();
        }
    }
}
