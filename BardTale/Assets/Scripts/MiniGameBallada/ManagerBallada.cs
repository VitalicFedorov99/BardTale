using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerBallada : MonoBehaviour
{
    //  [SerializeField] private
    [SerializeField] private List<CardModel> modelsInLevel;

    [SerializeField] private CardForBallada currentCard;

    [SerializeField] private TMPro.TMP_Text textScore;
    [SerializeField] private GameObject finishText;

    private int counter = 0;


    [SerializeField] private List<CardForBallada> handPlayer;
    [SerializeField] private List<CardModel> handCarModel = new List<CardModel>();
    [SerializeField] private List<CardModel> allModelsPLayer;
    [SerializeField] private StorageCard playerStorage;
    private CardModel temp;

    [SerializeField] private int score = 30;
    [SerializeField] private StateGame stateGame;

    
    public void CompareCard(int i)
    {
        // if(handPlayer[i] 
        if (stateGame != StateGame.Preparation)
            return;



        score += ReturnScore(handCarModel[i], currentCard.GetCardModel());
        textScore.text = score.ToString();
        counter++;
        if (counter >= modelsInLevel.Count)
        {
            EndLevel();
            return;
        }


        temp = handCarModel[i];
        handCarModel[i] = allModelsPLayer[0];
        allModelsPLayer.Remove(allModelsPLayer[0]);
        allModelsPLayer.Add(temp);
        SetupCardPlayer(i);
        SetupCurrentCard();
    }

    private void Start()
    {
        SetupGame();
    }
    public void SetupGame()
    {
        SetupCurrentCard();
        SetupAllCardsPlayer();
        MixingCardModelPlayer();
        MixingCardModelQuest();
        finishText.SetActive(false);
        score = 30;
        textScore.text = score.ToString();
        stateGame = StateGame.Preparation;
        for (int i = 0; i < handPlayer.Count; i++)
        {
            handCarModel.Add(new CardModel());
            TakeModel(i);
            SetupCardPlayer(i);
        }
    }

    public void Restart() 
    {
        counter = 0;
        MixingCardModelQuest();
        ReturnModel();
        MixingCardModelPlayer();
        SetupCurrentCard();
        score = 30;
        finishText.SetActive(false);
        textScore.text = score.ToString();
        stateGame = StateGame.Preparation;
        for (int i = 0; i < handPlayer.Count; i++)
        {
         //   handCarModel.Add(new CardModel());
            TakeModel(i);
            SetupCardPlayer(i);
        }


    }

    private void SetupCurrentCard()
    {
        currentCard.SetupCurrentCard(modelsInLevel[counter]);
    }

    private void SetupCardPlayer(int i)
    {
        handPlayer[i].SetupCurrentCard(handCarModel[i]);
    }

    private void SetupAllCardsPlayer()
    {
        allModelsPLayer = new List<CardModel>();
        foreach (var model in playerStorage.GetCards())
        {
            allModelsPLayer.Add(model);
        }
    }
    private void MixingCardModelPlayer()
    {
        allModelsPLayer.Sort((a, b) => Random.Range(-1, 1));
    }
    private void MixingCardModelQuest() 
    {
        modelsInLevel.Sort((a, b) => Random.Range(-1, 1));
    }
    private void EndLevel() 
    {
        stateGame = StateGame.EndGame;
        finishText.SetActive(true);
    }

    private void TakeModel(int i)
    {
        //temp = handCarModel[i];

        handCarModel[i] = allModelsPLayer[0];
        allModelsPLayer.Remove(allModelsPLayer[0]);
        // allModelsPLayer.Add(temp);
    }

    private void ReturnModel() 
    {
        var count = handCarModel.Count;
        for(int i = 0; i < count; i++) 
        {
            allModelsPLayer.Add(handCarModel[i]);
            //handCarModel.Remove(handCarModel[0]);
        }
     
    }


    private int ReturnScore(CardModel modelPlayer, CardModel modelQuest)
    {
        if (modelPlayer.nameCard == modelQuest.nameCard)
        {
            return 20;
        }
        if (modelPlayer.classCard == modelQuest.classCard)
        {
            return 10;
        }
        return -10;
    }




    public void Test()
    {
        Debug.Log(12345678);
    }
}
