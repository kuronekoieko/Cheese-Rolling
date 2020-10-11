using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] ParticleSystem attackPS;
    private void Awake()
    {

    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    public void PlayAttackEffect(Vector3 pos)
    {
        attackPS.transform.position = pos;
        attackPS.Play();
    }
}
