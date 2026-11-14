using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BinManager : MonoBehaviour
{
    [SerializeField] private List<BinLogic> binButtons;

    public BinLogic currentlyOpenButton = null;

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
}
