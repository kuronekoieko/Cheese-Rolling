using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class TargetIconController : MonoBehaviour
{
    [Inject] TargetController targetController;
    [SerializeField] RectTransform rectTransform;


    private void LateUpdate()
    {
        Vector3 targetPos = Camera.main.WorldToScreenPoint(targetController.transform.position);
        targetPos.y += 50f;
        rectTransform.position = targetPos;
    }
}
