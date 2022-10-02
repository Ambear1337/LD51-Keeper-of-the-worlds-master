using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using TMPro;

public class UI_Chest : MonoBehaviour {

    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private Chest chest;
    private bool isInventoryTurnedOn = false;

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");

        RefreshInventoryItems();
    }

    public void SetChest(Chest chest)
    {
        this.chest = chest;
        chest.enabled = true;
    }

    public void SetInventory(Inventory inventory) 
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;

        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e) 
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 75f;

        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            
            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () => 
            {
                // Use item
                inventory.UseItem(item);
            };
            itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () => 
            {
                // Drop item
                Item duplicateItem = new Item { itemType = item.itemType, amount = item.amount };
                inventory.RemoveItem(item);
                ItemWorld.DropItem(chest.GetPosition(), duplicateItem);
            };

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, -y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();

            TextMeshProUGUI uiText = itemSlotRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>();
            if (item.amount > 1) 
            {
                uiText.SetText(item.amount.ToString());
            } 
            else 
            {
                uiText.SetText("");
            }

            x++;
            if (x >= 4) {
                x = 0;
                y++;
            }
        }
    }

    public void TurnInventory()
    {
        //if (!player.enabled)
           // player.enabled = enabled;
        
        if (isInventoryTurnedOn)
        {
            isInventoryTurnedOn = false;
            Player.Instance.SetCameraLock(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            enabled = false;
        }
        else
        {
            isInventoryTurnedOn = true;
            Player.Instance.SetCameraLock(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            RefreshInventoryItems();
        }
    }
}
