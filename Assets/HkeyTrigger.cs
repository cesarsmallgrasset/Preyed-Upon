using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HkeyTrigger : MonoBehaviour
{
    private GameManager manager;
    private new BoxCollider collider;
    private void Awake()
    {
        manager = GameObject.FindObjectOfType<GameManager>();
        collider = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && manager.stormSpawn)
        {
            manager.keySpawn();
        }
    }

}
