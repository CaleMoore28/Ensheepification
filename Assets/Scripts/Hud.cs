using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    [SerializeField] private GameObject hudPanel;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private Image shiftTimer;
    [SerializeField] private GameObject interactPrompt;

    [Header("Dependencies")]
    [SerializeField] private MoneyManager moneyManager;
    [SerializeField] private ShiftManager shiftManager;


    private void Start()
    {
        hudPanel.SetActive(false);
        moneyManager.OnMoneyChanged += UpdateMoney;
    }

    private void Update()
    {
        shiftTimer.fillAmount = shiftManager.ShiftTimeAsProportion;
    }

    public void ToggleHud(bool toggle)
    {
        hudPanel.SetActive(toggle);
    }

    public void SetDay(int day)
    {
        dayText.text = "Day " + day.ToString();
    }

    public void ToggleInteractPrompt(bool toggle)
    {
        interactPrompt.SetActive(toggle);
    }

    private void UpdateMoney(int amount)
    {
        moneyText.text = "$" + amount.ToString();
    }
}
