using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    private Text myText;
    private int score = 0;

    void Awake()
    {
        myText = GetComponentInChildren<Text>();

    }

    public void SetScore(int i)
    {
        score = i;
        myText.text = score / 100 + "" + score / 10 % 10 + "" + score % 10;
    }

    public void AddScore()
    {
        SetScore(score + 1);
    }
}
