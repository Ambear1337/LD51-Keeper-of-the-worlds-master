using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldHandler : MonoBehaviour
{
    public List<GameObject> worlds;

    int currentWorldIndex = 0;

    public static WorldHandler Instance;

    public enum WorldType
    {
        forest,
        lava,
        ice,
        slime,
        underwater,
        corruption
    }

    private void Awake()
    {
        Instance = this;
    }

    IEnumerator ChangeWorldCouroutine()
    {
        yield return new WaitForSeconds(10f);
        ChangeWorld();
        StartGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartGame();
        }
    }

    public void ChangeWorld()
    {
        foreach (GameObject w in worlds)
        {
            w.SetActive(false);
        }

        int randomWorldIndex = currentWorldIndex;

        while (currentWorldIndex == randomWorldIndex)
        {
            randomWorldIndex = Random.Range(0, 6);
        }

        currentWorldIndex = randomWorldIndex;
        if (worlds[currentWorldIndex].GetComponent<World>().GetCorruped())
        {
            worlds[currentWorldIndex].GetComponent<World>().CorruptionProgress();
        }
        worlds[currentWorldIndex].SetActive(true);
    }

    public void StartGame()
    {
        StartCoroutine(ChangeWorldCouroutine());
    }

    public void EndGame()
    {
        StopCoroutine(ChangeWorldCouroutine());
        foreach (GameObject w in worlds)
        {
            w.SetActive(false);
        }
        currentWorldIndex = 0;
        worlds[0].SetActive(true);
    }
}
