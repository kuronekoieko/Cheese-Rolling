using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AIPlayerController : MonoBehaviour
{
    [Inject] CameraController cameraController;
    [Inject] PlayerController playerController;
    RagDollController ragDollController;

    private void Awake()
    {
        ragDollController = GetComponent<RagDollController>();
    }
    void Start()
    {

    }

    void Update()
    {
        //dx = Input.GetMouseButton(0) ? Input.GetAxis("Mouse X") : 0;
        //Debug.Log(JoystickInput.MouseDragVecNormalized);
    }


    private void FixedUpdate()
    {
        // ragDollController.AddForce(horizontalVec * dx * 1000);
        ragDollController.AddTorqueSpine(axis: playerController.horizontalVec.normalized, forward: cameraController.transform.forward);
    }
}
