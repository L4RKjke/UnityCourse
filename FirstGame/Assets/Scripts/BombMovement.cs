using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BombMovement : MonoBehaviour
{
    [SerializeField] private float _pathLength = 1.8f;
    [SerializeField] private float _bombSpeed = 4;

    private void Start()
    {
        transform.DOMove(new Vector3(transform.position.x - _pathLength, transform.position.y, 0), _bombSpeed).SetLoops(-1, LoopType.Yoyo);
    }
}
