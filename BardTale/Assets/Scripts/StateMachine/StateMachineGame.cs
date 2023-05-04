using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineGame : MonoBehaviour
{
    [SerializeField] private StateInMainGame stateMainGame = StateInMainGame.Game;


    public StateInMainGame GetState() => stateMainGame;

    public void SetStateInGame(StateInMainGame state) => stateMainGame = state;


}
public enum StateInMainGame 
{
    Menu,
    Setup,
    Dialog, //говорить
    Game //играть

}
