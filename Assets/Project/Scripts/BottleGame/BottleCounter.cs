using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BottleCounter : MonoBehaviour
{
   
    [SerializeField] private int bottleCount;
    [SerializeField] private GameObject bottleManagerReference;
    private BottleManager bottlemanager;
    TextContainer bottleText;

    private void Awake()
    {
        bottlemanager = bottleManagerReference.GetComponent<BottleManager>();
    }

    void Counter()
    {
        while (bottleCount < bottlemanager.numberInScene)
        {
        
        }
       

    }
}
