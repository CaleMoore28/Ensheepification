using TMPro;
using UnityEngine;

public class Hud : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;

    [Header("Dependencies")]
    [SerializeField] private MoneyManager moneyManager;


    private void Start()
    {
        moneyManager.OnMoneyChanged += UpdateMoney;
    }

    private void UpdateMoney(int amount)
    {
        moneyText.text = "$" + amount.ToString();
    }
}
