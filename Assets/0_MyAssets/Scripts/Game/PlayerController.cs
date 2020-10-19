using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public enum PlayerState
{
    Rolling,
    Goaled,
}
public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform rightHandTf;
    [SerializeField] TrailRenderer jumpTrail;
    RagDollController ragDollController;
    [Inject] CameraController cameraController;
    [Inject] GameManager gameManager;
    [Inject] TargetController targetController;
    [Inject] TargetIconController targetIconController;
    public Vector3 GetPosition => ragDollController.GetPosition;
    float dx;
    public Vector3 horizontalVec { get; set; }
    public Transform forwardTf;
    PlayerState playerState;
    BoxCollider floorCollider;

    private void Awake()
    {
        ragDollController = GetComponent<RagDollController>();
    }

    void Start()
    {
        horizontalVec = Vector3.Cross(forwardTf.forward, -Vector3.up);
        playerState = PlayerState.Rolling;
        jumpTrail.gameObject.SetActive(false);
    }


    void Update()
    {
        dx = JoystickInput.MouseDragVecNormalized.x;
    }


    private void FixedUpdate()
    {
        if (playerState == PlayerState.Rolling)
        {
            ragDollController.AddForceToMove(horizontalVec * dx * 2000);
            ragDollController.AddTorqueCenterSpineHorizontal(horizontalVec.normalized, 4000);
            ragDollController.AddForce(forwardTf.forward * 500f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        HitAIPlayer(other);
        HitJumpingBoard(other);
        HitFloor(other);
        HitTarget(other);
    }

    private void OnTriggerExit(Collider other)
    {
        ExitJumpingBoard(other);
    }

    void ExitJumpingBoard(Collider other)
    {
        var jumpingBoard = other.GetComponent<JumpingBoardController>();
        if (jumpingBoard == null) return;

    }

    void HitFloor(Collider other)
    {
        if (!other.gameObject.CompareTag("Floor")) return;
        jumpTrail.gameObject.SetActive(false);
        floorCollider = other.GetComponent<BoxCollider>();
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
        ragDollController.AddForce(Vector3.forward * 2000f, ForceMode.Impulse);
        jumpingBoard.IsUsed = true;
        jumpTrail.gameObject.SetActive(true);
    }
    void HitTarget(Collider other)
    {
        if (other.gameObject != targetController.gameObject) return;

        targetController.transform.parent = rightHandTf;
        targetController.transform.localPosition = Vector3.up * 0.065f;
        targetController.OnHitPlayer();
        playerState = PlayerState.Goaled;
        ragDollController.EnableRagdoll(false);
        transform.up = Vector3.up;
        transform.forward = -Vector3.forward;
        ragDollController.AnimSetBool("Goal", true);
        cameraController.GoaledAnim();
        targetIconController.gameObject.SetActive(false);
        var pos = transform.position;
        pos.y = floorCollider.transform.position.y + floorCollider.size.y / 2 * floorCollider.transform.localScale.y;
        transform.position = pos;
    }

}
