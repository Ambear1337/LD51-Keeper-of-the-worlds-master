using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable
{
    public string itemName;
    public Item item;
    public Color textColor;

    public override string GetDescription()
    {
        return "Collect " + itemName;
    }

    public override void Interact()
    {
        Player.Instance.AddItem(item);
        StartingItem startingItem = GetComponent<StartingItem>();
        if (startingItem != null)
        {
            startingItem.StartGame();
        }
        Destroy(this.gameObject);
    }

    public Color GetTextColor()
    {
        return textColor;
    }
}
