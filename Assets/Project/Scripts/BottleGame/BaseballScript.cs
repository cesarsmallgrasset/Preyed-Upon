using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballScript : MonoBehaviour
{
    private BottleManager bottlemanager;
    [SerializeField] GameObject item;
    private Vector3 StartPos;
    private Quaternion StartRot;
    internal bool complete = false;

    private void Awake()
    {
        bottlemanager = FindObjectOfType<BottleManager>();
    }
    private void Start()
    {
        StartPos = transform.position;
        StartRot = transform.rotation;
        Debug.Log(StartPos);
    }
    private void Update()
    {
        GameRestart();
    }
    void GameRestart()
    {
        if (bottlemanager.Restart)
        {

            this.transform.position = StartPos;
            this.transform.rotation = StartRot;
            Debug.Log("Ball Restart");

        }
    }
}

