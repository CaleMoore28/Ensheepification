using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    [SerializeField] private MoneyManager moneyManager;
    [SerializeField] private ShiftManager shiftManager;
    [SerializeField] private AnnouncementHandler announcementHandler;
    [SerializeField] private Hud hud;
    [SerializeField] private ScoreReportHandler reportHandler;
    [SerializeField] private TicketManager ticketManager;
    [SerializeField] private PlayerController playerController;

    [SerializeField] private BinManager binManager;

    private int day = 1;
    public int Day { get { return day; } }

    public string[] attributes= {"horns", "small"};
    public string[] tags= {"cute", "evil"};

    private Dictionary<int, int> dailyBudget = new Dictionary<int, int> 
    { 
        {1, 5000},
        {2, 2500},
        {3, 1000},
    };


    private void Start()
    {
        announcementHandler.ShowAnnouncement(day);
        announcementHandler.OnAnnouncementAcknowledged += StartDay;
    }

    private void StartDay()
    {
        announcementHandler.OnAnnouncementAcknowledged -= StartDay;

        playerController.ToggleMovement(true);

        moneyManager.OnBankrupt += OnBankrupt;
        shiftManager.OnShiftOver += OnShiftOver;

        hud.SetDay(day);

        hud.ToggleHud(true);
        moneyManager.SetBudget(dailyBudget[day]);
        moneyManager.SetBudget(dailyBudget[day]);
        shiftManager.StartShift();
        ticketManager.SetDay(day);

        binManager.CheckCorruption(day);
    }
    

    private void OnBankrupt()
    {
        moneyManager.OnBankrupt -= OnBankrupt;
        shiftManager.OnShiftOver -= OnShiftOver;

        Debug.Log("You Lose!");
    }

    private void OnShiftOver()
    {
        moneyManager.OnBankrupt -= OnBankrupt;
        shiftManager.OnShiftOver -= OnShiftOver;

        playerController.ToggleMovement(false);

        reportHandler.ShowScoreReport();
        reportHandler.OnLevelAdvance += ProgressDay;
    }

    private void ProgressDay()
    {
        day++;
        announcementHandler.ShowAnnouncement(day);
        announcementHandler.OnAnnouncementAcknowledged += StartDay;
    }

}
