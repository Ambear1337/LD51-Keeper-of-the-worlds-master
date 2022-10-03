using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour {

    public static ItemAssets Instance { get; private set; }

    private void Awake() 
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    public GameObject sunflowerGameObject;
    public GameObject lavaRoseGameObject;
    public GameObject coralGameObject;
    public GameObject lotusGameObject;
    public GameObject snowdropGameObject;

    public Sprite sunflowerSprite;
    public Sprite lavaRoseSprite;
    public Sprite coralSprite;
    public Sprite lotusSprite;
    public Sprite snowdropSprite;
}
