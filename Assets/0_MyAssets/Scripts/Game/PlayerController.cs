using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    RagDollController ragDollController;
    [Inject] CameraController cameraController;
    public Vector3 GetPosition => ragDollController.GetPosition;
    float dx;
    public Vector3 horizontalVec { get; set; }

    private void Awake()
    {
        ragDollController = GetComponent<RagDollController>();
    }
    
    void Start()
    {
        horizontalVec = Vector3.Cross(cameraController.transform.forward, -Vector3.up);
    }


    void Update()
    {
        dx = Input.GetMouseButton(0) ? Input.GetAxis("Mouse X") : 0;
        //dx = JoystickInput.MouseDragVecNormalized.x;
        // Debug.Log(JoystickInput.MouseDragVecNormalized);
    }


    private void FixedUpdate()
    {
        ragDollController.AddForce(horizontalVec * dx * 1000);
        ragDollController.AddTorqueSpine(axis: horizontalVec.normalized, forward: cameraController.transform.forward);
        //ragDollController.AddTorqueSpine(axis: cameraController.transform.forward * dx);
        // ragDollController.AddTorqueSpineHorizontal(dx);
    }
}
