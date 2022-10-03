using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using TMPro;
using CodeMonkey.Utils;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item) 
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    public static ItemWorld DropItem(Vector3 dropPosition, Item item)
    {
        Vector3 randomDir = UtilsClass.GetRandomDir();
        ItemWorld itemWorld = SpawnItemWorld(dropPosition + randomDir * 8f, item);
        itemWorld.GetComponent<Rigidbody>().AddForce(randomDir * 40f, ForceMode.Impulse);
        return itemWorld;
    }

    private Item item;

    public void SetItem(Item item) 
    {
        this.item = item;
    }

    public Item GetItem() 
    {
        return item;
    }

    public void DestroySelf() 
    {
        Destroy(gameObject);
    }
}
