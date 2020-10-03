using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] RagDollController ragDollController;
    float dx;
    void Start()
    {

    }


    void Update()
    {
        dx = 0;

        if (Input.GetMouseButton(0))
        {
            dx = Input.GetAxis("Mouse X");
        }

        Debug.Log(dx);


    }


    private void FixedUpdate()
    {
        ragDollController.AddForce(Vector3.right * dx * 500);
    }

    public Vector3 GetPosition => ragDollController.GetPosition;
}
