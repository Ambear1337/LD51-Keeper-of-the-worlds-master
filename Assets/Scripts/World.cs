using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : WorldHandler
{
    [Range(0, 100)]
    float corruptionProgress = 0f;

    bool corrupted = false;

    public Color fogColor;
    public Material skyboxMat;
    public WorldType worldType;

    public float fogStart = 15;
    public float fogEnd = 33;

    public void Corrupt()
    {
        corrupted = true;
    }

    public void CorruptionProgress()
    {
        corruptionProgress += 10f;
    }

    public bool GetCorruped()
    {
        return corrupted;
    }
}
