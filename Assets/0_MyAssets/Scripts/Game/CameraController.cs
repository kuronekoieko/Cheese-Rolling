using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Zenject;

public class CameraController : MonoBehaviour
{
    [Inject] PlayerController playerController;
    Vector3 offset;
    bool isGoaled;
    void Start()
    {
        offset = transform.position - playerController.GetPosition;
    }


    private void LateUpdate()
    {
        if (isGoaled) return;
        transform.position = playerController.GetPosition + offset;
    }

    public void GoaledAnim()
    {
        isGoaled = true;
        var pos = playerController.transform.position;
        pos.y += 1f;
        transform.DOMove(pos - Vector3.forward * 10f, 1f);
        var towards = pos;
        towards.y = transform.position.y;
        transform.DOLookAt(towards, 1f).OnComplete(() =>
        {
            Variables.screenState = ScreenState.Clear;
        });
    }
}
