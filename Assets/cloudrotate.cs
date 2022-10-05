using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudrotate : MonoBehaviour
{
    [SerializeField] private float rotation;

    void Update()
    {
        transform.Rotate(Vector3.up, rotation);        
    }
}
