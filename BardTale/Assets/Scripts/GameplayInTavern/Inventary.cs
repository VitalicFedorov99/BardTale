using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class Inventary : MonoBehaviour
{
    [SerializeField] private int countMoney;
    [SerializeField] private TMP_Text textMoney;

    public int GetCountMoney() => countMoney;

    public void AddMoney(int money)
    {
        if (money > 0)
        {
            countMoney += money;
            textMoney.text = money.ToString();
        }
    }

    public void Subtraction(int money)
    {
        if (money <= countMoney)
        {
            countMoney -= money;
            textMoney.text = money.ToString();
        }
    }

    public bool CheckMoneyForSubstraction(int money)
    {
        if (money <= countMoney)
        {
            return true;
        }
        return false;
    }

}
