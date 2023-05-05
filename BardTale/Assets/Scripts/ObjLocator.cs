using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLocator : MonoBehaviour
{
    public static ObjLocator instance;

    [SerializeField] private ManagerGameDialog managerGameDialog;

    [SerializeField] private DialogManager dialogManager;

    [SerializeField] private DialogMemory dialogMemory;

    [SerializeField] private StateMachineGame stateMachineGame;

    [SerializeField] private Inventary inventaryPlayer;

    [SerializeField] private QuestObserver questObserver;

    [SerializeField] private ManagerGame managerGame;

    [SerializeField] private NPCStorage npcStorage;

    [SerializeField] private OutCome outcome;
    public ManagerGameDialog GetManagerGameDialog() => managerGameDialog;
    public DialogManager GetDialogManager() => dialogManager;

    public DialogMemory GetDialogMemeory() => dialogMemory;

    public StateMachineGame GetStateMachineGame() => stateMachineGame;

    public Inventary GetInventary() => inventaryPlayer;

    public QuestObserver GetQuestObserver() => questObserver;

    public ManagerGame GetManagerGame() => managerGame;

    public NPCStorage GetNPCStorage() => npcStorage;

    public OutCome GetOutCome() => outcome;

    private void Awake()
    {
        instance = this;
    }
}
