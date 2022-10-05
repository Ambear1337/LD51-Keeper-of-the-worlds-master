using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldsManager : MonoBehaviour
{
    public enum WorldType
    {
        forest,
        lava,
        ice,
        slime,
        underwater,
        corruption
    }

    public WorldType startWorldType = WorldType.forest;

    public static WorldsManager Instance;
}
