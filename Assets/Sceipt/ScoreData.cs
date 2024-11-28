using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData : MonoBehaviour
{
    public int Score;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public int GetScore()
    {
        return Score;
    }
}
