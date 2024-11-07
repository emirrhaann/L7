using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class RewardPropMove : MonoBehaviour
{
    public void Awake()
    {
        transform.DOScale(Vector3.one * 1.5f, 1).SetEase(Ease.OutBounce).SetLoops(-1, LoopType.Yoyo);
        transform.DORotate(Vector3.one * 2, 1).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}