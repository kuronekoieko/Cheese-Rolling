using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    void Start()
    {
        rb.maxAngularVelocity = 1000f;
    }

    private void FixedUpdate()
    {
        rb.AddTorque(transform.up * 100f);
    }
}
