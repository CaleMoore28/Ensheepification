using System;
using UnityEngine;

public class AnnouncementHandler : MonoBehaviour
{
    [SerializeField] GameObject announcementPanel;

    public Action OnAnnouncementAcknowledged;


    public void ShowAnnouncement(int day)
    {
        announcementPanel.SetActive(true);
    }

    public void AcknowledgeAnnouncement()
    {
        announcementPanel.SetActive(false);
        OnAnnouncementAcknowledged?.Invoke();
    }
}
