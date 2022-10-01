using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour {

    public static ItemAssets Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }

    public Transform pfItemWorld;

    public Mesh woodMesh;
    public Mesh stoneMesh;
    public Mesh axeMesh;

    public Sprite woodSprite;
    public Sprite stoneSprite;
    public Sprite axeSprite;

}
