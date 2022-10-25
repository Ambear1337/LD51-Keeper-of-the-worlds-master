using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionPanel : MonoBehaviour
{
    public LevelManager manager;

    public void TransitToNextScene()
    {
        manager.EndGame();
    }
}
