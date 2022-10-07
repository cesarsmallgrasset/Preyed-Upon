using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballScript : MonoBehaviour
{
    private BottleManager bottlemanager;
    [SerializeField] GameObject item;
    private Transform StartPos;
    private void Awake()
    {
        bottlemanager = FindObjectOfType<BottleManager>();
    }
    private void Start()
    {
        StartPos.SetPositionAndRotation(item.transform.position, item.transform.rotation);

    }
    private void Update()
    {
        GameRestart();
    }
    void GameRestart()
    {
        if (bottlemanager.Restart)
        {
            item.gameObject.transform.SetPositionAndRotation(StartPos.position, StartPos.rotation);
            Debug.Log("Ball Restart");
        }
    }

}

