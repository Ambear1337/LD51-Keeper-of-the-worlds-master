using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldHandler : MonoBehaviour
{
    public List<GameObject> worlds;

    int currentWorldIndex = 0;

    public bool startChangeWorld = false;
    public WorldType startWorldType = WorldType.forest;

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
        if (startChangeWorld)
        {
            foreach (GameObject w in worlds)
            {
                if (w.GetComponent<World>().worldType == startWorldType)
                {
                    ChangeWorldOnStartWorld(w.GetComponent<World>());
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }

    IEnumerator ChangeWorldCouroutine()
    {
        yield return new WaitForSeconds(10f);
        ChangeWorld();
        StartGame();
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

        ChangeWorldColor(worlds[currentWorldIndex].GetComponent<World>().fogColor, worlds[currentWorldIndex].GetComponent<World>().skyboxMat, worlds[currentWorldIndex].GetComponent<World>().fogStart, worlds[currentWorldIndex].GetComponent<World>().fogEnd);
        worlds[currentWorldIndex].SetActive(true);
    }

    public void StartGame()
    {
        StartCoroutine(ChangeWorldCouroutine());
    }

    public void EndGame()
    {
        foreach (GameObject w in worlds)
        {
            w.SetActive(false);
        }
        worlds[0].SetActive(true);
        StopCoroutine(ChangeWorldCouroutine());
    }

    void ChangeWorldColor(Color fogColor, Material skybox, float fogStart, float fogEnd)
    {
        RenderSettings.fogColor = fogColor;
        RenderSettings.fogStartDistance = fogStart;
        RenderSettings.fogEndDistance = fogEnd;
        RenderSettings.skybox = skybox;
    }

    void ChangeWorldOnStartWorld(World world)
    {
        foreach (GameObject w in worlds)
        {
            w.SetActive(false);
        }

        if (worlds[currentWorldIndex].GetComponent<World>().GetCorruped())
        {
            worlds[currentWorldIndex].GetComponent<World>().CorruptionProgress();
        }

        ChangeWorldColor(world.fogColor, world.skyboxMat, world.fogStart, world.fogEnd);
        world.gameObject.SetActive(true);
    }

    public void TeleportToCorruption()
    {
        foreach (GameObject w in worlds)
        {
            w.SetActive(false);
        }

        foreach (GameObject w in worlds)
        {
            if (w.GetComponent<World>().worldType == WorldType.corruption)
            {
                ChangeWorldColor(w.GetComponent<World>().fogColor, w.GetComponent<World>().skyboxMat, w.GetComponent<World>().fogStart, w.GetComponent<World>().fogEnd);
                w.SetActive(true);
            }
        }
    }
}
