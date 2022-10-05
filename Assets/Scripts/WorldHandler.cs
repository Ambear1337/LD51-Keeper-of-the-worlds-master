using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldHandler : MonoBehaviour
{
    public List<GameObject> worlds;
    public List<Item> plantsCollected;

    int currentWorldIndex = 0;

    public bool startChangeWorld = false;
    bool changingWorlds = false;

    public int forestWorld;
    public int corruptionWorld;

    public WorldsManager manager;

    public static WorldHandler Instance;

    private void Awake()
    {
        Instance = this;

        for (int w = 0; w < worlds.Count; w++)
        {
            if (worlds[w].GetComponent<World>().worldType == WorldsManager.WorldType.forest)
            {
                forestWorld = w;
            }

            if (worlds[w].GetComponent<World>().worldType == WorldsManager.WorldType.corruption)
            {
                corruptionWorld = w;
            }
        }

        if (startChangeWorld)
        {
            for (int w = 0; w < worlds.Count; w++)
            {
                if (worlds[w].GetComponent<World>().worldType != manager.startWorldType)
                {
                    continue;
                }
                else
                {
                    ChangeWorld(w);
                    break;
                }
            }
        }
    }

    IEnumerator RandomChangingWorldCouroutine()
    {
        while (changingWorlds)
        {
            yield return new WaitForSeconds(10f);
            if (changingWorlds)
            {
                ChangeWorld(GetRandomWorldIndex());
            }
            else
            {
                ChangeWorld(corruptionWorld);
            }
        }
    }

    public void ChangeWorld(int worldIndex)
    {
        currentWorldIndex = worldIndex;
        
        foreach (GameObject w in worlds)
        {
            w.SetActive(false);
        }

        ChangeWorldColor(worlds[currentWorldIndex].GetComponent<World>().fogColor, worlds[currentWorldIndex].GetComponent<World>().skyboxMat, worlds[currentWorldIndex].GetComponent<World>().fogStart, worlds[currentWorldIndex].GetComponent<World>().fogEnd);
        worlds[currentWorldIndex].SetActive(true);
    }

    public void StartGame()
    {
        changingWorlds = true;
        StartCoroutine(RandomChangingWorldCouroutine());
    }

    public void EndGame()
    {
        changingWorlds = false;
        StopCoroutine(RandomChangingWorldCouroutine());

        ChangeWorld(forestWorld);
    }

    void ChangeWorldColor(Color fogColor, Material skybox, float fogStart, float fogEnd)
    {
        RenderSettings.fogColor = fogColor;
        RenderSettings.fogStartDistance = fogStart;
        RenderSettings.fogEndDistance = fogEnd;
        RenderSettings.skybox = skybox;
    }

    public void TeleportToCorruption()
    {
        ChangeWorld(corruptionWorld);
    }

    public int GetRandomWorldIndex()
    {
        int randomWorldIndex = currentWorldIndex;
        
        if (changingWorlds)
        {
            while (worlds[randomWorldIndex].GetComponent<World>().plantCollected || randomWorldIndex == currentWorldIndex)
            {
                randomWorldIndex = Random.Range(0, 6);
                Debug.Log(randomWorldIndex);

                if (randomWorldIndex == currentWorldIndex)
                {
                    randomWorldIndex = corruptionWorld;
                    break;
                }
            }
        }
        else
        {
            randomWorldIndex = forestWorld;
        }

        return randomWorldIndex;
    }
}
