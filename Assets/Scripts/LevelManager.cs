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



    private int day = 1;
    public int Day { get { return day; } }

    public string[] attributes= {"horns", "small"};
    public string[] tags= {"cute", "evil"};

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
        announcementHandler.ShowAnnouncement(day);
        announcementHandler.OnAnnouncementAcknowledged += StartDay;
    }

    private void StartDay()
    {
        announcementHandler.OnAnnouncementAcknowledged -= StartDay;

        playerController.ToggleMovement(true);

        moneyManager.OnBankrupt += OnBankrupt;
        shiftManager.OnShiftOver += OnShiftOver;


        moneyManager.SetBudget(dailyBudget[Day]);
        shiftManager.StartShift();
        ticketManager.SetDay(day);

        hud.SetDay(day);

        hud.ToggleHud(true);
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
