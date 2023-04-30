using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interlocutor
{

    private int countChips;
    private int level;
    private bool isDrunk;

    public void SetupInterlocutor(int count)
    {
        countChips = count;
    }


    public int GetCountChips() => countChips;
    public int GetLevel() => level;
    public bool GetDrunk() => isDrunk;
    public void Drunk() => isDrunk = true;



}
