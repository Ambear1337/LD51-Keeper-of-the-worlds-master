using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Monument : Interactable
{
    public List<Transform> itemsPlaces;

    public Monument corruptionMonument;

    public List<GameObject> items;

    public override string GetDescription()
    {
        return "Place item on monument.";
    }

    public override void Interact()
    {
        Item item = Player.Instance.GetItem();
        Debug.Log(item.itemType);
        if (item != null)
        {
            AddItem(item);
        }
    }

    public void AddItem(Item i)
    {
        if (i != null)
        {
            foreach (Transform p in itemsPlaces)
            {
                ItemPlace place = p.gameObject.GetComponent<ItemPlace>();
                if (!place.itemPlaced)
                {
                    place.PlaceItem(i.GetGameObject());
                    items.Add(place.gameObject);
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        if (items.Count >= 5)
        {
            Debug.Log("Game over.");
            WorldHandler.Instance.EndGame();
        }
    }
}
