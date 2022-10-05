using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleGame : MonoBehaviour
{
    [SerializeField] private List<GameObject> bottles = new List<GameObject>();
    [SerializeField] private List<GameObject> balls = new List<GameObject>();

    private List<Transform> bottles1 = new List<Transform>();
    private List<Transform> balls1 = new List<Transform>();


    private void Awake()
    {
        for (int i = 0; i < bottles.Count; i++)
        {
            bottles1[i] = bottles[i].transform;
            balls1[i] = balls[i].transform;
        }
    }



}
