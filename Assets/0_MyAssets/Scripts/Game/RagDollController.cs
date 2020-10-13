using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Zenject;

public class RagDollController : MonoBehaviour
{
    Rigidbody[] rigidbodies;
    [SerializeField] Rigidbody[] spineRigidbodies;
    Animator animator;

    private void Awake()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        spineRigidbodies[1].maxAngularVelocity = 4000;
        EnableRagdoll(true);
    }

    public void AddForceToMove(Vector3 force, ForceMode mode = ForceMode.Force)
    {
        if (spineRigidbodies[1].velocity.sqrMagnitude > 500) return;
        spineRigidbodies[1].AddForce(force, mode);
    }

    public void AddForce(Vector3 force, ForceMode mode = ForceMode.Force)
    {
        spineRigidbodies[1].AddForce(force, mode);
    }

    public void AddTorqueCenterSpineHorizontal(Vector3 axis, float power)
    {
        var center = GetPosition;
        spineRigidbodies[1].AddTorque(axis * 1000f);
    }

    public Vector3 GetPosition
    {
        get
        {
            Vector3 pos = Vector3.zero;
            foreach (var rigidbody in rigidbodies)
            {
                pos += rigidbody.transform.position;
            }

            return pos / (float)rigidbodies.Length;
        }
    }

    public void EnableRagdoll(bool enabled)
    {
        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = !enabled;
        }
        animator.enabled = !enabled;
    }

    public void AnimSetBool(string name, bool value)
    {
        animator.SetBool(name, value);
    }
}
