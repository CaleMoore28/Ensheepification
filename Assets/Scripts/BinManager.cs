using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BinManager : MonoBehaviour
{
    [SerializeField] private List<BinLogic> binButtons;

    public BinLogic currentlyOpenButton = null;

    private int loopIndex = 0;

    public void NormalizeBinList()
    {
        foreach (BinLogic button in binButtons)
        {
            if (button.binIsOpen)
            {
                button.NormalizeCloseBin(button.gameObject);
                currentlyOpenButton = null;
            }
        }
    }

    public void ChangeOpenBinStatus(GameObject bin)
    {
        currentlyOpenButton = bin.GetComponent<BinLogic>();
    }

    public void CheckCorruption(int day)
    {
        switch (day)
        {
            default:
                break;

            // 0-5 uncoorrupted
            case (1):
                loopIndex = 5;
                break;

            // 6 - 9
            case (2):
                loopIndex = 9;
                break;

            // 10 - 13
            case (3):
                loopIndex = 13;
                break;
        }

        SetAllowedButtons(loopIndex);
    }

    private void SetAllowedButtons(int index)
    {
        for (int i = 0; i <= index; i++)
        {
            binButtons[i].gameObject.SetActive(true);
        }
    }
}
