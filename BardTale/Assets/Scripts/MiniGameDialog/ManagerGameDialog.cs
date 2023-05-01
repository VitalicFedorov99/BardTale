using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;
public class ManagerGameDialog : MonoBehaviour
{
    [SerializeField] private List<PlaceForChips> placeEnemy;
    [SerializeField] private List<PlaceForChips> placePlayer;
    [SerializeField] private List<GameObject> placeFight;

    [SerializeField] private List<GameObject> allChips;
    [SerializeField] private List<GameObject> chipsEnemy = new List<GameObject>();
    [SerializeField] private List<GameObject> chipsPlayer = new List<GameObject>();

    //  [SerializeField] private List<GameObject> activChipsEnemy = new List<GameObject>();
    [SerializeField] private List<GameObject> activChipsPlayer = new List<GameObject>();

    [SerializeField] private List<int> ideaEnemy = new List<int>();
    [SerializeField] private List<TypeEmotion> hintEmotions = new List<TypeEmotion>();

    [SerializeField] private TMP_Text textHint;
    [SerializeField] private TMP_Text textScorePlayer;
    [SerializeField] private TMP_Text textScoreEnemy;

    [SerializeField] private StateGame stateGame = StateGame.Preparation;


    [SerializeField] private Manager21Score manager;
    [SerializeField] private GameObject gameBoard;

    private bool isEndGame = false;
    private int counterPlayer;
    private int counterEnemy;
    private int maxScore;

    private int counterChipsEnemy;

    private int scorePlayer;
    private int scoreEnemy;
    private Interlocutor enemy;
    private Interlocutor player;

    private void Start()
    {
        enemy = new Interlocutor();
        enemy.SetupInterlocutor(3);

        player = new Interlocutor();
        player.SetupInterlocutor(3);
        SetInterlocutor(enemy, player);
        Setup(5);
    }

    public void Setup(int maxScore)
    {
        this.maxScore = maxScore;
        isEndGame = false;
    }

    public void Open() 
    {
        textHint.gameObject.SetActive(true);
        textScoreEnemy.gameObject.SetActive(true);
        textScorePlayer.gameObject.SetActive(true);
        gameBoard.SetActive(true);
        Preparation();
    }

    public void Close() 
    {
        textHint.gameObject.SetActive(false);
        textScoreEnemy.gameObject.SetActive(false);
        textScorePlayer.gameObject.SetActive(false);
        gameBoard.SetActive(false);
    }

    public void Battle()
    {
        stateGame = StateGame.Battle;
        StepEnemy();
        for (int i = 0; i < placeFight.Count; i++)
        {
            if (placeEnemy[i].GetChip() != null && placePlayer[i].GetChip() != null)
            {

                MoveChips(placeEnemy[i].GetChip(), placePlayer[i].GetChip(), i);
            }


            if (placeEnemy[i].GetChip() != null && placePlayer[i].GetChip() == null)
            {
                MoveChipEnemy(placeEnemy[i].GetChip(), i);
            }

        /*    if (placeEnemy[i].GetChip() == null && placePlayer[i].GetChip() != null)
            {
                MoveChipsPlayer(placePlayer[i].GetChip(), i);
            }*/
        }

       // CountScore();
       // Preparation();
    }


    public void OpenGame21Score() 
    {
        Close();
        manager.OpenGame();
    }
    public void Preparation()
    {
        Clear();
        stateGame = StateGame.Preparation;
        EnemyPut();
    }

    
    public void SetInterlocutor(Interlocutor enemy, Interlocutor player)
    {
        this.enemy = enemy;
        this.player = player;
        var count = enemy.GetCountChips();
        counterEnemy = count;
        for (int i = 0; i < count; i++)
        {
            chipsEnemy.Add(allChips[0]);
            allChips.Remove(allChips[0]);
        }
        count = player.GetCountChips();
        counterPlayer = count;
        for (int i = 0; i < count; i++)
        {
            chipsPlayer.Add(allChips[0]);
            allChips.Remove(allChips[0]);
        }

        EnemyPut();

    }

    public void AcceptResult21Score(int result) 
    {
        scorePlayer += result;
        manager.CloseGame();
        Clear();
        CountScore();
        Open();
    }

    public void StepEnemy()
    {

        counterChipsEnemy = 0;
        for (int i = 0; i < ideaEnemy.Count; i++)
        {
            chipsEnemy[counterChipsEnemy].transform.position = placeEnemy[ideaEnemy[i]].transform.position;
            placeEnemy[ideaEnemy[i]].SetChip(chipsEnemy[counterChipsEnemy]);
            counterChipsEnemy++;

        }
    }

    public void Restart() 
    {
        scorePlayer = 0;
        scoreEnemy = 0;
        CountScore();
        Preparation();
    }

    public void ToPutChip(int number)
    {

        if (stateGame != StateGame.Preparation)
            return;

        if (!placePlayer[number].GetPut() && chipsPlayer.Count > 0)
        {
            //chipsPlayer[localCounterChipsPlayer].transform.position = placePlayer[number].transform.position;
            var temp = chipsPlayer[0];
            activChipsPlayer.Add(chipsPlayer[0]);
            temp.transform.position = placePlayer[number].transform.position;
            chipsPlayer.Remove(chipsPlayer[0]);
            placePlayer[number].Put();
            placePlayer[number].SetChip(temp);
            return;
        }
        if (placePlayer[number].GetPut())
        {
            var temp = placePlayer[number].GetChip();
            activChipsPlayer.Remove(temp);
            chipsPlayer.Add(temp);
            temp.transform.position = new Vector3(150, 150, 150);
            placePlayer[number].Put();
            placePlayer[number].RemoveChip();
            return;
        }
    }
    private void EnemyPut()
    {

        ideaEnemy.Clear();
        hintEmotions.Clear();
        int rand = 0;
        while (ideaEnemy.Count < counterEnemy)
        {
            rand = Random.Range(0, 5);
            //if(rand==5)
            //{
            //    rand = 4;
            //}
            if (!ideaEnemy.Contains(rand))
            {
                ideaEnemy.Add(rand);
            }
        }

        GenerateHint(1);
    }


    private void GenerateHint(int count)
    {
        int rand = 0;
        TypeEmotion tE = TypeEmotion.Joy;
        while (hintEmotions.Count < count)
        {
            rand = Random.Range(0, ideaEnemy.Count);
            tE = NumberToTypeEmotion(ideaEnemy[rand]);
            if (!hintEmotions.Contains(tE))
            {
                hintEmotions.Add(tE);
            }
        }
        textHint.text = "";
        for (int i = 0; i < hintEmotions.Count; i++)
        {
            textHint.text = textHint.text + hintEmotions[i].ToString() + " ";
        }

    }

    

    private void Clear() 
    {
        var count = activChipsPlayer.Count;
        for(int i = 0; i < count; i++) 
        {
            chipsPlayer.Add(activChipsPlayer[0]);
            activChipsPlayer.Remove(activChipsPlayer[0]);
        }

        for(int i = 0; i < chipsPlayer.Count; i++) 
        {
            chipsPlayer[i].transform.position = new Vector3(150, 150, 150);
        }


        for (int i = 0; i < chipsEnemy.Count; i++)
        {
            chipsEnemy[i].transform.position = new Vector3(0, 0, 150);
        }
        for ( int i=0;i<placeEnemy.Count; i++) 
        {
            placeEnemy[i].RemoveChip();
            placePlayer[i].RemoveChip();
            placePlayer[i].Setup();
        }
    }

    private TypeEmotion NumberToTypeEmotion(int number)
    {
        switch (number)
        {
            case 0:
                return TypeEmotion.Joy;
            case 1:
                return TypeEmotion.Sadnes;
            case 2:
                return TypeEmotion.Disgust;
            case 3:
                return TypeEmotion.Angry;
            case 4:
                return TypeEmotion.Fear;
        }
        return TypeEmotion.Joy;
    }

    private void MoveChips(GameObject chipEnemy, GameObject chipPlayer, int number)
    {
        Debug.Log("бой " + number);
    }

    private void MoveChipsPlayer(GameObject chipPlayer, int number)
    {
        Debug.Log("игрок " + number);
        scorePlayer++;
    }

    private void MoveChipEnemy(GameObject chipEnemy, int number)
    {
        
        Debug.Log("враг " + number);
        scoreEnemy++;
     
    }


    private void CountScore()
    {
        textScoreEnemy.text = scoreEnemy.ToString();
        textScorePlayer.text = scorePlayer.ToString();
        CheckEndGame();

    }

    private void Lose() 
    {
        isEndGame = true;
    }

    private void Win() 
    {
        isEndGame = true;
    }
    private void CheckEndGame()
    {
        if (scoreEnemy >= maxScore && scoreEnemy>scorePlayer) 
        {
            Lose();
        }
        if(scorePlayer>=maxScore && scorePlayer >= scoreEnemy) 
        {
            Win();
        }
    }
}


public enum TypeEmotion
{
    Joy,
    Sadnes,
    Disgust,
    Angry,
    Fear
}
public enum StateGame
{
    Preparation,
    Battle,
    Counting,
    EndGame
}