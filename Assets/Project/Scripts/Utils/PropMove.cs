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
            transform.DOMoveY(transform.position.y + 0.5f, 2f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
        }
    }


    void Destroy()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter()
    {
        GetComponent<BoxCollider>().enabled = false;
        /*if (tag == "Coin")
        {
            transform.DOPath(new[] { transform.position, transform.position + new Vector3(-2, 2.5f, 10) }, .8f)
                .SetEase(Ease.OutBack);
        }*/

        transform.DOPath(new[] { transform.position, transform.position + new Vector3(-1, -1, 1) }, .8f)
            .SetEase(Ease.OutBack);
        transform.DOScale(Vector3.one * 0, .8f).SetEase(Ease.InBack).OnComplete(Destroy);
    }

    void Update()
    {
    }
}