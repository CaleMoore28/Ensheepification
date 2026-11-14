using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BinLogic : MonoBehaviour
{
    [SerializeField] private List<GameObject> binParts;

    [Header("Dependencies")]
    [SerializeField] private BinManager binManager;

    public bool binIsOpen = false;

    public void ChangeBinState()
    {
        binManager.NormalizeBinList();

        if (binIsOpen)
        {
            CloseBins();
        }
        else
        {
            OpenBins();
        }

        binManager.ChangeOpenBinStatus(gameObject)
    }

    private void OpenBins()
    {
        foreach (GameObject bin in binParts)
        {
            bin.SetActive(true);
        }
        binIsOpen = true;
    }

    private void CloseBins()
    {
        foreach (GameObject bin in binParts)
        {
            bin.SetActive(false);
        }
        binIsOpen = false;
    }

    public void NormalizeCloseBin(GameObject binToClose)
    {
        foreach (GameObject bin in binParts)
        {
            bin.SetActive(false);
        }
        binIsOpen = false;
    }

}
