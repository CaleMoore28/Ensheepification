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
        StartDay();
    }

    private void StartDay()
    {
        announcementHandler.OnAnnouncementAcknowledged -= StartDay;

        moneyManager.OnBankrupt += OnBankrupt;
        shiftManager.OnShiftOver += OnShiftOver;
        

        hud.SetDay(day);

        hud.ToggleHud(true);
        moneyManager.SetBudget(dailyBudget[day]);
        shiftManager.StartShift();
        ticketManager.SetDay(day);

    
    }

    private void OnShiftOver()
    {
        moneyManager.OnBankrupt -= OnBankrupt;
        shiftManager.OnShiftOver -= OnShiftOver;

        reportHandler.ShowScoreReport();
        if (day != 3){
            reportHandler.OnLevelAdvance += ProgressDay;
        }else{
            GameManager.Instance.MountScene("FinalCutscene");
        }

    }

    private void OnBankrupt()
    {
        moneyManager.OnBankrupt -= OnBankrupt;
        shiftManager.OnShiftOver -= OnShiftOver;
        GameManager.Instance.bankrupt= true;
        GameManager.Instance.MountScene("FinalCutscene");

    }

    private void ProgressDay()
    {
        day++;
        announcementHandler.ShowAnnouncement(day);
        announcementHandler.OnAnnouncementAcknowledged += StartDay;
    }



}
