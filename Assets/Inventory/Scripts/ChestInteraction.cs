using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : Interactable
{
    public bool isOn = false;
    public Chest chest;

    private void Start()
    {
        
    }

    public override string GetDescription()
    {
        if (!isOn)
        {
            return "Press [E] to <color=green>open</color> house's chest.";
        }
        else
        {
            return "Press [E] to <color=red>close</color> house's chest.";
        }
    }

    public override void Interact()
    {
        if (!isOn)
        {
            chest.GetUIChest().gameObject.SetActive(true);
            isOn = true;
        }
        else
        {
            chest.GetUIChest().gameObject.SetActive(false);
            isOn = false;
        }
    }
}
