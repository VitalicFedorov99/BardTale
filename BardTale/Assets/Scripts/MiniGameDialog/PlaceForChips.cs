using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceForChips : MonoBehaviour
{
    [SerializeField] private bool isPut;
    [SerializeField] private int number;
    [SerializeField] private GameObject chip;
  
    public void Setup() 
    {
        isPut = false;
    }

    public void Put() 
    {
        if (isPut) 
        {
            isPut = false;
            return;
        }
        else 
        {
            isPut = true;
            return;
        }
    }

    public bool GetPut() => isPut;

    public int GetNumber() => number;

    public GameObject GetChip() => chip;

    public void SetChip(GameObject obj) => chip = obj;

    public void RemoveChip() => chip = null;
}
