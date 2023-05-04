using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour,IInteraction
{
    [SerializeField] private int cost;

    public string GetName()
    {
        return "Монета";
    }

    public string GetNameAction()
    {
        return "Взять";
    }

    public void Interaction()
    {
        ObjLocator.instance.GetInventary().AddMoney(cost);
        gameObject.SetActive(false);
    }
}
