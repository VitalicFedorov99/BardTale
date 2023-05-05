using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutCome : MonoBehaviour
{
    [SerializeField] private int numberDay;


    public void SetupDay(int number) => numberDay = number;

    public void IncludeConsequences(TypeQuest typeQuest)
    {
        switch (numberDay)
        {
            case 1:
                break;
            case 2:
                ConsequencesSecondDay(typeQuest);
                break;
        }
    }

    public void ConsequencesSecondDay(TypeQuest typeQuest)
    {
        var idAnna = ObjLocator.instance.GetNPCStorage().GetAnna().GetIdNPC();
        var idWitcher = ObjLocator.instance.GetNPCStorage().GetWitcher().GetIdNPC();
        var idOleg = ObjLocator.instance.GetNPCStorage().GetOleg().GetIdNPC();
        var idTesak = ObjLocator.instance.GetNPCStorage().GetTesak().GetIdNPC();
        switch (typeQuest)
        {

            case TypeQuest.Negative:
                ObjLocator.instance.GetDialogMemeory().SetNumberDialogs(idWitcher, 10);
                ObjLocator.instance.GetDialogMemeory().SetNumberDialogs(idAnna, 10);
                break;

            case TypeQuest.Positive:

                ObjLocator.instance.GetDialogMemeory().SetNumberDialogs(idTesak, 10);
                ObjLocator.instance.GetDialogMemeory().SetNumberDialogs(idWitcher, 10);
                ObjLocator.instance.GetDialogMemeory().SetNumberDialogs(idAnna, 10);

                break;

            case TypeQuest.Neutral:

                ObjLocator.instance.GetDialogMemeory().SetNumberDialogs(idOleg, 11);
                ObjLocator.instance.GetDialogMemeory().SetNumberDialogs(idTesak, 10);
                ObjLocator.instance.GetDialogMemeory().SetNumberDialogs(idAnna, 10);
                break;
        }
    }
}
