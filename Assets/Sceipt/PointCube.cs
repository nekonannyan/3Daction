using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCube : MonoBehaviour
{
    [SerializeField] private ScoreData scoreData;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scoreData.Score += 1;
            Destroy(gameObject);
        }
    }
}
