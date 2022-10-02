using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Inventory inventory;

    [SerializeField] 
    private UI_Chest uiChest;

    private void Awake()
    {
        inventory = new Inventory(UseItem);

        uiChest.SetInventory(inventory);
    }

    private void UseItem(Item item)
    {

    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public UI_Chest GetUIChest()
    {
        return uiChest;
    }
}
