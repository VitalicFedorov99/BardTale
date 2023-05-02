using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    [SerializeField] Vector3 target;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ThirdPersonController player)) 
        {
            if (!player.GetUseStair()) 
            {
                player.UseStair(target);
            }
        }
    }
}
