using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSTargets : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] GunShoot gunshoot;
    [SerializeField] private Vector3 hitForce;
    [SerializeField] GameObject Target;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gunshoot.hit.collider == Target)
        {
            rb.AddForce(hitForce, ForceMode.Impulse);
        }
    }
}
