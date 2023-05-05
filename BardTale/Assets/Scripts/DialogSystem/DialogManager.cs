using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using TMPro;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour
{
    //[SerializeField] private TMP_Text textDialogue;
    [SerializeField] private Text textDialogue;

    [SerializeField] private int idDialogue;

    [SerializeField] private List<Text> textButtons;
    [SerializeField] private List<Button> objButtons;
    [SerializeField] private List<GameObject> imageButtons;
    [SerializeField] private List<GameObject> imageGame;
    [SerializeField] private List<GameObject> imageMoney;
    [SerializeField] private GameObject closeButton;
    [SerializeField] private GameObject dialogNPCWindow;
    [SerializeField] private GameObject dialogBardWindow;


    [SerializeField] private List<StorageDialogOneDay> storages;

    [SerializeField] private int numberDay;


    private char delimiter = '|';
    [SerializeField] private List<string> allTextBard;
    [SerializeField] private List<string> allTextNPC;

    [SerializeField] private int idNPC = 0;

    private int numberDialogue;
    private string[] currentDialogueVariant = new string[3];
    private string currentDialogNPC;
    private int[] numberNextDialog = new int[3];
    private int counterCurrentDialogue = 0;
    private int numberGame;

    private int loseInMiniGame;
    private int winMiniGame;
    private bool isMiniGame;


    private bool isBuy;
    private int summa;
    private int numberDialogBuy;
    int numberBuy;

    //private string[]
    public void SetupDialog(int id)
    {
        idNPC = id;
        ObjLocator.instance.GetStateMachineGame().SetStateInGame(StateInMainGame.Dialog);
        numberDialogue = ObjLocator.instance.GetDialogMemeory().GetNumberDialogs(id);
        Clear();
        OpenDialog();
        SetupAllTextDialogue(id);
        UpdateDialog();
    }

    public void UpdateDialog()
    {
        //ObjLocator.instance.GetDialogMemeory().SetNumberDialogs(idNPC, numberDialogue);
        ClearCurrentDialogueVariant();
        ObjLocator.instance.GetDialogMemeory().AddNumberDealog(numberDialogue, idNPC);
        SplitDialogueBard(numberDialogue);
        SetupWindowDialogueNPC();
        SetupWindowDialogueBard();
    }




    private void Start()
    {
        numberDialogue = 1;
        numberDay = 1;

        //SetupDialog(0);
    }

    private void Clear()
    {
        isMiniGame = false;
        loseInMiniGame = 0;
        winMiniGame = 0;
    }

    private void SetupAllTextDialogue(int id)
    {
        allTextBard = storages[numberDay - 1].GetDialoguesBard(id);
        allTextNPC = storages[numberDay - 1].GetDialogueNPC(id);
        isMiniGame = storages[numberDay - 1].CheckMiniGame(id, out loseInMiniGame, out winMiniGame);
        isBuy = storages[numberDay - 1].CheckIsBuy(id, out summa, out numberDialogBuy);
    }

    private void ClearCurrentDialogueVariant()
    {
        for (int i = 0; i < 3; i++)
        {
            currentDialogueVariant[i] = "";
        }
    }

    private void SplitDialogueBard(int number)
    {
        counterCurrentDialogue = 0;
        var count = 0;
        var flag = false;
        numberGame = 5;
        numberBuy = 5;
        foreach (string text in allTextBard)
        {
            string[] substrings = text.Split(delimiter);
            if (Convert.ToInt32(substrings[1]) == numberDialogue)
            {
                if (substrings[3] != "norm")
                {
                    Debug.LogError("попал сюда");
                    switch (substrings[3])
                    {
                        case "p":
                            count = Convert.ToInt32(substrings[4]);
                            flag = ObjLocator.instance.GetQuestObserver().CheckPositiveQuest(count);
                            break;
                        case "neit":
                            count = Convert.ToInt32(substrings[4]);
                            flag = ObjLocator.instance.GetQuestObserver().CheckNeutralQuest(count);
                            break;
                        case "negat":
                            count = Convert.ToInt32(substrings[4]);
                            flag = ObjLocator.instance.GetQuestObserver().CheckNegativeQuest(count);
                            break;
                    }
                    if (flag)
                    {
                        currentDialogueVariant[counterCurrentDialogue] = substrings[0];
                        if (substrings[2] != "g" && substrings[2] != "m")
                        {
                            numberNextDialog[counterCurrentDialogue] = Convert.ToInt32(substrings[2]);
                        }
                        if (substrings[2] == "g")
                        {
                            numberGame = counterCurrentDialogue;
                        }

                        if (substrings[2] == "m")
                        {
                            numberBuy = counterCurrentDialogue;
                        }


                    }
                }
                else
                {
                    currentDialogueVariant[counterCurrentDialogue] = substrings[0];
                    if (substrings[2] != "g" && substrings[2] != "m")
                    {
                        numberNextDialog[counterCurrentDialogue] = Convert.ToInt32(substrings[2]);
                    }
                    if (substrings[2] == "g")
                    {
                        numberGame = counterCurrentDialogue;
                    }

                    if (substrings[2] == "m")
                    {
                        numberBuy = counterCurrentDialogue;
                    }
                }


                counterCurrentDialogue++;
            }

        }
    }


    private void SetupWindowDialogueNPC()
    {
        currentDialogNPC = "";
        foreach (string text in allTextNPC)
        {
            string[] substrings = text.Split(delimiter);
            if (Convert.ToInt32(substrings[1]) == numberDialogue)
            {


                if (substrings[2] != "norm")
                {

                    switch (substrings[2])
                    {
                        case "p":
                            var count = Convert.ToInt32(substrings[3]);
                            var flag = ObjLocator.instance.GetQuestObserver().CheckPositiveQuest(count);
                            if (flag)
                            {
                                ObjLocator.instance.GetQuestObserver().AddPositionQuest(TypeQuest.Positive);
                                currentDialogNPC = substrings[0];
                                ObjLocator.instance.GetDialogMemeory().SetLastMessage(idNPC, currentDialogNPC);
                            }
                            break;
                        case "neit":
                            count = Convert.ToInt32(substrings[3]);
                            flag = ObjLocator.instance.GetQuestObserver().CheckNeutralQuest(count);
                            if (flag)
                            {
                                ObjLocator.instance.GetQuestObserver().AddPositionQuest(TypeQuest.Neutral);
                                currentDialogNPC = substrings[0];
                                ObjLocator.instance.GetDialogMemeory().SetLastMessage(idNPC, currentDialogNPC);
                            }
                            break;
                        case "negat":
                            count = Convert.ToInt32(substrings[3]);
                            flag = ObjLocator.instance.GetQuestObserver().CheckNegativeQuest(count);
                            if (flag)
                            {
                                ObjLocator.instance.GetQuestObserver().AddPositionQuest(TypeQuest.Negative);
                                currentDialogNPC = substrings[0];
                                ObjLocator.instance.GetDialogMemeory().SetLastMessage(idNPC, currentDialogNPC);
                            }
                            break;
                    }
                }
                else
                {
                    currentDialogNPC = substrings[0];
                    ObjLocator.instance.GetDialogMemeory().SetLastMessage(idNPC, currentDialogNPC);
                }
            }
        }

        textDialogue.text = currentDialogNPC;
        if (currentDialogNPC == "") 
        {
            textDialogue.text = ObjLocator.instance.GetDialogMemeory().GetLastMessage(idNPC);
        }
    }

    private void SetupWindowDialogueBard()
    {
        for (int i = 0; i < 3; i++)
        {
            imageGame[i].SetActive(false);
            imageMoney[i].SetActive(false);
            if (currentDialogueVariant[i] != "")
            {
                textButtons[i].text = currentDialogueVariant[i];
                objButtons[i].gameObject.SetActive(true);
                imageButtons[i].SetActive(true);
                if (i == numberGame)
                {

                    imageGame[i].SetActive(true);
                    if (ObjLocator.instance.GetDialogMemeory().GetWinGame(idNPC))
                    {
                        textButtons[i].text += " (Победа)";
                    }
                }
                if (i == numberBuy)
                {
                    imageGame[i].SetActive(true);
                }
            }

            else
            {
                objButtons[i].gameObject.SetActive(false);
                imageButtons[i].SetActive(false);
                textButtons[i].text = "";
            }
        }
    }


    public void OpenMiniGame()
    {
        ObjLocator.instance.GetManagerGameDialog().OpenNewGame();
        CloseDialogForMiniGame();
    }


    public void WinMiniGame()
    {
        OpenDialog();
        numberDialogue = winMiniGame;
        ObjLocator.instance.GetDialogMemeory().AddWinGame(idNPC);
        UpdateDialog();
    }

    public void LoseMiniGame()
    {
        OpenDialog();
        numberDialogue = loseInMiniGame;
        UpdateDialog();
    }

    public void NextDialog(int i)
    {
        numberDialogue = numberNextDialog[i];
        if (i == numberGame)
        {
            OpenMiniGame();
        }
        if (i == numberBuy)
        {
            if (ObjLocator.instance.GetInventary().CheckMoneyForSubstraction(summa))
            {
                Debug.Log("зашел");
                ObjLocator.instance.GetInventary().Subtraction(summa);
                ObjLocator.instance.GetDialogMemeory().SetNumberDialogs(idNPC, numberDialogBuy);
                UpdateDialog();
            }
        }
        else
            UpdateDialog();
    }

    public void CloseDialogForMiniGame()
    {
        dialogBardWindow.SetActive(false);
        dialogNPCWindow.SetActive(false);

    }
    public void CloseDialog()
    {
        dialogBardWindow.SetActive(false);
        dialogNPCWindow.SetActive(false);
        ObjLocator.instance.GetStateMachineGame().SetStateInGame(StateInMainGame.Game);
    }

    public void OpenDialog()
    {
        dialogBardWindow.SetActive(true);
        dialogNPCWindow.SetActive(true);
    }

    public void DisableExit()
    {
        closeButton.SetActive(false);
    }

    public void EnableExit()
    {
        closeButton.SetActive(true);
    }


}
