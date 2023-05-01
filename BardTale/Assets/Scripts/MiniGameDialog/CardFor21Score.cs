using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
public class CardFor21Score : MonoBehaviour
{

    [SerializeField] private TMP_Text textCard;
    [SerializeField] private Image imageCard;
    [SerializeField] private TMP_Text textValue;
    [SerializeField] private int value;

    private Manager21Score manager;

    public void Setup(string text, Sprite sprite, int value, Manager21Score manager)
    {
        textCard.text = text;
        imageCard.sprite = sprite;
        textValue.text = value.ToString();
        this.value = value;
        this.manager = manager;
    }

    public void Call() 
    {
        manager.ChooseCard(value);
    }

    public void Test() => Debug.Log(12345);


}
