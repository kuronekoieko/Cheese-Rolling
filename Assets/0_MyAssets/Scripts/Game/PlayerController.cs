﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    RagDollController ragDollController;
    [Inject] CameraController cameraController;
    [Inject] GameManager gameManager;
    public Vector3 GetPosition => ragDollController.GetPosition;
    float dx;
    public Vector3 horizontalVec { get; set; }
    public Transform forwardTf;

    private void Awake()
    {
        ragDollController = GetComponent<RagDollController>();
    }

    void Start()
    {
        horizontalVec = Vector3.Cross(forwardTf.forward, -Vector3.up);
    }


    void Update()
    {
        // dx = Input.GetMouseButton(0) ? Input.GetAxis("Mouse X") : 0;
        dx = JoystickInput.MouseDragVecNormalized.x;
        // Debug.Log(JoystickInput.MouseDragVecNormalized);
    }


    private void FixedUpdate()
    {
        ragDollController.AddForceToMove(horizontalVec * dx * 2000);
        //ragDollController.AddTorqueSpine(axis: horizontalVec.normalized, forward: forwardTf.forward);
        ragDollController.AddTorqueCenterSpineHorizontal(horizontalVec.normalized, 3000);
        //ragDollController.AddTorqueSpine(axis: cameraController.transform.forward * dx);
        // ragDollController.AddTorqueSpineHorizontal(dx);
    }

    private void OnTriggerEnter(Collider other)
    {
        HitAIPlayer(other);
        HitJumpingBoard(other);
    }


    void HitAIPlayer(Collider other)
    {
        var aiPlayer = other.gameObject.GetComponent<AIPlayerController>();
        if (aiPlayer == null) return;

        aiPlayer.Attacked(horizontalVec * (aiPlayer.transform.position.x - transform.position.x));
        gameManager.PlayAttackEffect(aiPlayer.transform.position);
    }

    void HitJumpingBoard(Collider other)
    {
        var jumpingBoard = other.GetComponent<JumpingBoardController>();
        if (jumpingBoard == null) return;
        if (jumpingBoard.IsUsed) return;
        ragDollController.AddForceToAttacked(forwardTf.forward * 4000f);
        jumpingBoard.IsUsed = true;
        Debug.Log("aaaaaaaaaaaaaaaaa");
    }

}
