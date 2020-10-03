using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] RagDollController ragDollController;
    [Inject] CameraController cameraController;
    float dx;
    void Start()
    {

    }


    void Update()
    {
        dx = Input.GetMouseButton(0) ? Input.GetAxis("Mouse X") : 0;
    }


    private void FixedUpdate()
    {
        Vector3 cross = Vector3.Cross(cameraController.transform.forward, -Vector3.up);
        ragDollController.AddForce(cross * dx * 500);
    }

    public Vector3 GetPosition => ragDollController.GetPosition;
}
