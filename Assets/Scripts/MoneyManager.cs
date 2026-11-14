using System;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    int currentMoney = 0;

    public Action<int> OnMoneyChanged;
    public Action OnBankrupt;

    public void SetBudget(int amount)
    {
        currentMoney = amount;

        OnMoneyChanged?.Invoke(currentMoney);
    }

    public void IncrementMoney(int amount)
    {
        currentMoney += amount;

        OnMoneyChanged?.Invoke(currentMoney);

        if (currentMoney < 0)
        {
            OnBankrupt?.Invoke();
        }
    }
}
