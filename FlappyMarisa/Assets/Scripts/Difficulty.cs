using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public static Difficulty instance;
    private float rate = 1;

    void Awake()
    {
        instance = this;
    }

    public void SetRate(float r)
    {
        rate = r;
    }

    public float GetRate()
    {
        return rate;
    }

    public void LevelUp()
    {
        if (rate < 3)
        {
            rate += 0.02f;
        }
    }

}
