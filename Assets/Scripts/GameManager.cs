using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    LevelManager levelManager;

    public bool gameEnded = false;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (gameEnded)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                levelManager.LoadNextScene();
            }
        }
    }

    public void EndGame()
    {
        gameEnded = true;
    }
}
