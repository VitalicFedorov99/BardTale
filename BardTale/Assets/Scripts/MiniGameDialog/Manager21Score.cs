using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Manager21Score : MonoBehaviour
{
    [SerializeField] private GameObject scaleGame;
    [SerializeField] private List<GameObject> places;
    [SerializeField] private GameObject counter;
    [SerializeField] private GameObject containerGame;
    [SerializeField] private int testStartId;


    [SerializeField] private List<CardFor21Score> cardForms;
    [SerializeField] private StorageFor21Score storage;
    [SerializeField] private int minValue;
    [SerializeField] private int maxValue;

    [SerializeField] private ManagerGameDialog manager;


    private Sprite currentSprite;
    private string currentText;
    private int currentValue;
    private List<int> idforUse = new List<int>();
    private int currentPlayerScore = 0;
    private int rand;

    private void Start()
    {
        counter.transform.position = places[testStartId].transform.position;
    }

    public void ChooseCard(int value)
    {
        currentPlayerScore += value;
        counter.transform.position = places[currentPlayerScore].transform.position;
        if (CheckEndGame()) 
        {
            ToSumUp();
        }
        else 
        {
            CreateCard();
        }

    }

   

    public void Pass()
    {
        ToSumUp();
    }



    public void OpenGame() 
    {
        scaleGame.SetActive(true);
        counter.SetActive(true);
        containerGame.SetActive(true);
        Setup();
        CreateCard();
    }

    public void CloseGame() 
    {
        OffCard();
        containerGame.SetActive(false);
        scaleGame.SetActive(false);
        counter.SetActive(false);
    }

    public void Setup()
    {
        currentPlayerScore = 0;
        counter.transform.position = places[currentPlayerScore].transform.position;
    }

    
    private void CreateCard()
    {
        var countStorage = storage.GetCount();
        while (idforUse.Count != cardForms.Count)
        {
            rand = Random.Range(0, countStorage);
            if (!idforUse.Contains(rand))
            {
                idforUse.Add(rand);
            }
        }
        for (int i = 0; i < cardForms.Count; i++)
        {
            currentText = storage.GetText(idforUse[i]);
            currentSprite = storage.GetSprite(idforUse[i]);
            currentValue = Random.Range(minValue, maxValue);
            cardForms[i].Setup(currentText, currentSprite, currentValue, this);
            cardForms[i].gameObject.SetActive(true);
        }
    }

    private void OffCard()
    {
        for (int i = 0; i < cardForms.Count; i++)
        {
            cardForms[i].gameObject.SetActive(false);
        }
    }

    private bool CheckEndGame()
    {
        if (currentPlayerScore >= 21)
        {
            return true;
        }
        return false;
    }

    private void ToSumUp()
    {

        if (currentPlayerScore == 21)
        {
            manager.AcceptResult21Score(3);
            return;
        }
        if (currentPlayerScore < 21 && currentPlayerScore >= 18)
        {
            manager.AcceptResult21Score(2);
            return;
        }
        if(currentPlayerScore>21 && currentPlayerScore <= 24) 
        {
            manager.AcceptResult21Score(2);
            return;
        }
        if( currentPlayerScore<18 && currentPlayerScore >= 15) 
        {
            manager.AcceptResult21Score(1);
            return;
        }
        if(currentPlayerScore>24 && currentPlayerScore <= 27) 
        {
            manager.AcceptResult21Score(1);
            return;
        }

    }

}
