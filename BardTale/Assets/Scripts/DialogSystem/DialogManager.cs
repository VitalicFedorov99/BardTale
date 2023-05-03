using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using TMPro;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textDialogue;


    [SerializeField] private int idDialogue;

    [SerializeField] private List<TMP_Text> textButtons;
    [SerializeField] private List<Button> objButtons;
    [SerializeField] private List<GameObject> imageButtons;
    [SerializeField] private GameObject closeButton;
    [SerializeField] private GameObject dialogNPCWindow;
    [SerializeField] private GameObject dialogBardWindow;


    [SerializeField] private List<StorageDialogOneDay> storages;

    [SerializeField] private int numberDay;


    private char delimiter = '|';
    [SerializeField] private List<string> allTextBard;
    [SerializeField] private List<string> allTextNPC;

    private int numberDialogue;
    private string[] currentDialogueVariant = new string[3];
    private int counterCurrentDialogue = 0;
    //private string[]
    public void SetupDialog(int id)
    {
        OpenDialog();
        SetupAllTextDialogue(id);
        ClearCurrentDialogueVariant();
        Split(numberDialogue);
        SetupWindowDialogueBard();
    }


    private void Start()
    {
        numberDialogue = 1;
        numberDay = 1;
        SetupDialog(0);
    }

    private void SetupAllTextDialogue(int id)
    {
        allTextBard = storages[numberDay - 1].GetDialoguesBard(id);
        allTextNPC = storages[numberDay - 1].GetDialogueNPC(id);
    }

    private void ClearCurrentDialogueVariant()
    {
        for (int i = 0; i < 3; i++)
        {
            currentDialogueVariant[i] = "";
        }
    }

    private void Split(int number)
    {
        counterCurrentDialogue = 0;
        foreach (string text in allTextBard)
        {
            string[] substrings = text.Split(delimiter);
            if (Convert.ToInt32(substrings[1]) == numberDialogue)
            {
                currentDialogueVariant[counterCurrentDialogue] = substrings[0];
                counterCurrentDialogue++;
            }
        }
    }

    private void SetupWindowDialogueBard()
    {
        for (int i = 0; i < 3; i++)
        {
            if (currentDialogueVariant[i] != "")
            {
                textButtons[i].text = currentDialogueVariant[i];
                objButtons[i].gameObject.SetActive(true);
                imageButtons[i].SetActive(true);
            }
            else
            {
                objButtons[i].gameObject.SetActive(false);
                imageButtons[i].SetActive(false);
                textButtons[i].text = "";
            }
        }
    }




    public void CloseDialog()
    {
        dialogBardWindow.SetActive(false);
        dialogNPCWindow.SetActive(false);
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
