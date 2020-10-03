﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Zenject;

public class CameraController : MonoBehaviour
{
    [Inject] PlayerController playerController;
    Vector3 offset;
    void Start()
    {
        offset = transform.position - playerController.GetPosition;
    }

    void Update()
    {
        transform.position = playerController.GetPosition + offset;
    }
}
