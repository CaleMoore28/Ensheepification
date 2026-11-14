using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    [SerializeField] MoneyManager moneyManager;

    private int day = 1;
    public int Day { get { return day; } }

    private Dictionary<int, int> dailyBudget = new Dictionary<int, int> 
    { 
        {1, 500},
        {2, 500},
        {3, 400},
        {4, 400},
        {5, 300},
        {6, 300},
        {7, 200},
    };


    private void Start()
    {
        moneyManager.OnBankrupt += OnBankrupt;
        StartDay();
    }

    private void StartDay()
    {
        moneyManager.SetBudget(dailyBudget[Day]);
    }

    private void OnBankrupt()
    {
        Debug.Log("You Lose!");
    }

}
