using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BottleScript : MonoBehaviour
{
    private BottleManager bottlemanager;
    [SerializeField] GameObject item;
    private Vector3 StartPos;
    private Quaternion StartRot;
    internal bool complete = false;



    AudioSource audioSource;
    private void Awake()
    {
        bottlemanager = FindObjectOfType<BottleManager>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartPos = transform.position;
        StartRot = transform.rotation;
    }
    private void Update()
    {
        GameRestart();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "SM_Prop_Crate")
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }


    void GameRestart()
    {
        if (bottlemanager.Restart)
        {
            this.transform.position = StartPos;
            this.transform.rotation = StartRot;
            Debug.Log("Bottle Restart");
        }
    }

}
