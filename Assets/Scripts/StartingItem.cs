using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingItem : MonoBehaviour
{
    public void StartGame()
    {
        WorldHandler.Instance.StartGame();
    }
}
