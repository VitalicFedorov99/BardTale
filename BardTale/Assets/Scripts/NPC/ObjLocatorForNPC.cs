using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLocatorForNPC : MonoBehaviour
{
    public List<GameObject> poinstWalking;

    public static ObjLocatorForNPC instance;
    private void Awake()
    {
        instance = this;
    }
}
