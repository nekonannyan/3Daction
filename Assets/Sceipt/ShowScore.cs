using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private ScoreData score;

    private void Start()
    {
        
    }
    private void Update()
    {
        text.text = string.Format($"{score.GetScore()}/5");
    }
}
