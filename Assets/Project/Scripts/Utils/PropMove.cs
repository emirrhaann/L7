using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class PropMove : MonoBehaviour
{
    private void Start()
    {
        {
            transform.DOScale(Vector3.one * 1, 0.7f).OnComplete(PropsMove);
        }
    }
    void PropsMove()
    {
        transform.DOMoveY(transform.position.y + 0.5f, 2f).SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter()
    {
        transform.DOPath(new[] { transform.position, transform.position + new Vector3(-5, -2, 2) }, .8f);
        transform.DOScale(Vector3.one * 1.5f, .8f).SetEase(Ease.OutElastic).OnComplete(Destroy);
    }
}