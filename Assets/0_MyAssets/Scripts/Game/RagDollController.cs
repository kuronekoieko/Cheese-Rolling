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

    private void Awake()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    void Start()
    {
        spineRigidbodies[1].maxAngularVelocity = 1000;
    }

    public void AddForceCenterSpine(Vector3 force, ForceMode mode = ForceMode.Force)
    {
        spineRigidbodies[1].AddForce(force, mode);
    }

    public void AddTorqueCenterSpineHorizontal(Vector3 axis)
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

    /*
    
        public void AddForce(Vector3 force, ForceMode mode = ForceMode.Force)
    {
        foreach (var rigidbody in rigidbodies)
        {
            rigidbody.AddForce(force, mode);
        }
    }


    public void AddTorque(Vector3 axis)
    {
        var center = GetPosition;
        //float avr = rigidbodies.Average(r => r.velocity.magnitude);
        foreach (var rigidbody in rigidbodies)
        {
            Vector3 posFromCenter = rigidbody.transform.position - center;
            Vector3 addVec = -Vector3.Cross(posFromCenter, axis);
            Vector3 project = Vector3.Project(posFromCenter, center + axis);

            Vector3 normal = posFromCenter - project;
            //Debug.Log(rigidbody.name + " " + normal.magnitude);
            //if (1 < rigidbody.velocity.sqrMagnitude) continue;
            //Debug.Log(rigidbody.transform.name);
            if (spineRigidbodies.FirstOrDefault(r => r == rigidbody) == null) return;
            //rigidbody.AddForce(addVec * 100);
            Debug.Log(rigidbody.name);
            rigidbody.AddTorque(Vector3.up * 1000);
        }
    }


    public void AddTorqueSpine(Vector3 axis, Vector3 forward)
    {
        var center = GetPosition;
        //float avr = rigidbodies.Average(r => r.velocity.magnitude);
        foreach (var rigidbody in spineRigidbodies)
        {
            Vector3 posFromCenter = rigidbody.transform.position - center;
            Vector3 addVec = -Vector3.Cross(posFromCenter.normalized, axis);
            // Debug.Log(axis.magnitude);
            //Vector3 project = Vector3.Project(posFromCenter, center + playerController.horizontalVec);

            //Vector3 normal = posFromCenter - project;
            //Debug.Log(rigidbody.name + " " + normal.magnitude);
            //if (1 < rigidbody.velocity.sqrMagnitude) continue;
            //Debug.Log(rigidbody.transform.name);
            //if (spineRigidbodies.FirstOrDefault(r => r == rigidbody) == null) return;
            if (rigidbody.velocity.sqrMagnitude > 100) continue;

            //           if (addVec.y > 0) continue;
            rigidbody.AddForce(addVec * 3000 + forward * 1200);

            // Debug.Log(rigidbody.velocity.magnitude);
            // rigidbody.AddTorque(playerController.horizontalVec * 1000000000);
        }
    }

    public void AddTorqueSpineHorizontal(float dx)
    {
        var center = GetPosition;
        //float avr = rigidbodies.Average(r => r.velocity.magnitude);
        foreach (var rigidbody in rigidbodies)
        {
            Vector3 posFromCenter = rigidbody.transform.position - center;
            // Vector3 addVec = dx * Vector3.Cross(posFromCenter, cameraController.transform.forward);
            //Vector3 project = Vector3.Project(posFromCenter, center + playerController.horizontalVec);

            //Vector3 normal = posFromCenter - project;
            //Debug.Log(rigidbody.name + " " + normal.magnitude);
            //if (1 < rigidbody.velocity.sqrMagnitude) continue;
            //Debug.Log(rigidbody.transform.name);
            //if (spineRigidbodies.FirstOrDefault(r => r == rigidbody) == null) return;
            if (rigidbody.velocity.magnitude > 10) return;
            // rigidbody.AddForce(addVec * 2000);

            //Debug.Log(rigidbody.velocity.magnitude);
            // rigidbody.AddTorque(playerController.horizontalVec * 1000000000);
        }
    }*/






}
