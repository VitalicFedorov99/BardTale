using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStorage : MonoBehaviour
{
    [SerializeField] private NPC banditTesak;

    [SerializeField] private NPC banditOleg;

    [SerializeField] private NPC oficiantAnna;

    [SerializeField] private NPC tractirchic;

    [SerializeField] private NPC witcher;

    [SerializeField] private GameObject player;

    public NPC GetTesak() => banditTesak;
    public NPC GetOleg() => banditOleg;

    public NPC GetAnna() => oficiantAnna;

    public NPC GetTractirchic() => tractirchic;

    public NPC GetWitcher() => witcher;

    public GameObject GetPlayer() => player;

   
}
