using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monument : Interactable
{
    public List<Transform> itemsPlaces;
    
    public override string GetDescription()
    {
        return "Place items on monument.";
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

    void AddItem(Item i)
    {
        if (i != null)
        {
            foreach (Transform p in itemsPlaces)
            {
                if (p.childCount <= 0)
                {
                    Instantiate(i.GetGameObject(), p.position, Quaternion.identity, p);
                    return;
                }
                else
                {
                    continue;
                }
            }
        }

        if (itemsPlaces[0].childCount > 0 && itemsPlaces[1].childCount > 0 && itemsPlaces[2].childCount > 0 && itemsPlaces[3].childCount > 0 && itemsPlaces[4].childCount > 0)
        {
            WorldHandler.Instance.EndGame();
        }
    }
}
