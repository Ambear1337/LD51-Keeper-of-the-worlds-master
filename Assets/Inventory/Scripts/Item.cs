using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item {

    public enum ItemType {
        Wood,
        Stone,
        Axe,
    }

    public ItemType itemType;
    public int amount;


    public Sprite GetSprite() {
        switch (itemType) {
        default:
        case ItemType.Wood:        return ItemAssets.Instance.woodSprite;
        case ItemType.Stone: return ItemAssets.Instance.stoneSprite;
        case ItemType.Axe:   return ItemAssets.Instance.axeSprite;
        }
    }

    public Mesh GetMesh()
    {
        switch (itemType)
        {
            default:
            case ItemType.Wood: return ItemAssets.Instance.woodMesh;
            case ItemType.Stone: return ItemAssets.Instance.stoneMesh;
            case ItemType.Axe: return ItemAssets.Instance.axeMesh;
        }
    }

    public Color GetColor() {
        switch (itemType) {
        default:
        case ItemType.Wood:        return new Color(1, 1, 1);
        case ItemType.Stone: return new Color(1, 0, 0);
        case ItemType.Axe:   return new Color(0, 0, 1);
        }
    }

    public bool IsStackable() {
        switch (itemType) {
        default:
        case ItemType.Wood:
        case ItemType.Stone:
            return true;
        case ItemType.Axe:
            return false;
        }
    }

}
