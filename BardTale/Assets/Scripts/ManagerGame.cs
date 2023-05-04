using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGame : MonoBehaviour
{
    [SerializeField] private int currentDay;

    [SerializeField] private int maxDay;

    [SerializeField] private int score;

    public int GetCurrentDay() => currentDay;
    public void AddScore(int point) => score += point;

    public int GetScore() => score;
}
