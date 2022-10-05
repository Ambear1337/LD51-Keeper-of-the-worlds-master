using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlace : MonoBehaviour
{
    public bool itemPlaced = false;

    public void PlaceItem(GameObject item)
    {
        Instantiate(item, transform.position, Quaternion.identity, transform);
        itemPlaced = true;
    }
}
