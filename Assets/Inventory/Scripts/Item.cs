using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item {

    public enum ItemType 
    {
        Sunflower,
        LavaRose,
        Coral,
        Lotus,
        Snowdrop
    }

    public ItemType itemType;
    public int amount;

    public GameObject GetGameObject()
    {
        switch (itemType)
        {
            default:
            case ItemType.Sunflower: return ItemAssets.Instance.sunflowerGameObject;
            case ItemType.LavaRose: return ItemAssets.Instance.lavaRoseGameObject;
            case ItemType.Coral: return ItemAssets.Instance.coralGameObject;
            case ItemType.Lotus: return ItemAssets.Instance.lotusGameObject;
            case ItemType.Snowdrop: return ItemAssets.Instance.snowdropGameObject;
        }
    }

    public Sprite GetSprite() 
    {
        switch (itemType)
        {
        default:
        case ItemType.Sunflower: return ItemAssets.Instance.sunflowerSprite;
        case ItemType.LavaRose: return ItemAssets.Instance.lavaRoseSprite;
        case ItemType.Coral: return ItemAssets.Instance.coralSprite;
        case ItemType.Lotus: return ItemAssets.Instance.lotusSprite;
        case ItemType.Snowdrop: return ItemAssets.Instance.snowdropSprite;
        }
    }

    public Color GetColor() 
    {
        switch (itemType) 
        {
        default:
        case ItemType.Sunflower: return Color.yellow;
        }
    }

    public bool IsStackable() 
    {
        switch (itemType) 
        {
        default:
            return true;
        case ItemType.Sunflower:
        case ItemType.LavaRose:
        case ItemType.Lotus:
        case ItemType.Coral:
        case ItemType.Snowdrop:
                return false;
        }
    }

}
