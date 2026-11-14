using System;
using UnityEngine;

public class ScoreReportHandler : MonoBehaviour
{
    [SerializeField] private GameObject scoreReportPanel;

    public Action OnLevelAdvance;


    private void Start()
    {
        scoreReportPanel.SetActive(false);
    }

    public void ShowScoreReport()
    {
        scoreReportPanel.SetActive(true);
    }

    public void OnNextLevelPressed()
    {
        scoreReportPanel.SetActive(false);
        OnLevelAdvance?.Invoke();
    }
}
