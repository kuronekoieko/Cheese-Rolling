using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDollController : MonoBehaviour
{
    Rigidbody[] rigidbodies;

    private void Awake()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    void Start()
    {

    }

    public void AddForce(Vector3 force, ForceMode mode = ForceMode.Force)
    {
        foreach (var rigidbody in rigidbodies)
        {
            rigidbody.AddForce(force, mode);
        }
    }
}
