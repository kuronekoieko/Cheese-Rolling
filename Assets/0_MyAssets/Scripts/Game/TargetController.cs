using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Collider col;
    [SerializeField] TrailRenderer trailRenderer;
    void Start()
    {
        rb.maxAngularVelocity = 1000f;
    }

    private void FixedUpdate()
    {
        rb.AddTorque(transform.up * 100f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Goal")) return;
        rb.constraints = RigidbodyConstraints.None;
        rb.AddTorque(transform.forward * 1000f, ForceMode.Impulse);
    }

    public void OnHitPlayer()
    {
        col.enabled = false;
        rb.isKinematic = true;
        trailRenderer.enabled = false;
    }
}
