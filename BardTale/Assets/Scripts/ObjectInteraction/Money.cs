using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour,IInteraction
{
    [SerializeField] private int cost;

    public string GetName()
    {
        return "������";
    }

    public string GetNameAction()
    {
        return "�����";
    }

    public void Interaction()
    {
        ObjLocator.instance.GetInventary().AddMoney(cost);
        gameObject.SetActive(false);
    }
}
