using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{

    public int score = 0;

    void Awake()
    {
    }

    public void AddPoints()
    {
        score++;
        Debug.Log("Score: " + score);
    }
}
