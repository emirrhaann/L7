using DG.Tweening;
using UnityEngine;

namespace Project.Scripts.Utils
{
    public class PropMove : MonoBehaviour
    {
        private void Start()
        {
            {
                transform.DOScale(Vector3.one * 1, 0.7f).OnComplete(PropsMove);
            }
        }

        private void PropsMove()
        {
            transform.DOMoveY(transform.position.y + 0.5f, 2f).SetEase(Ease.InOutQuad)
                .SetLoops(-1, LoopType.Yoyo);
        }
        void Destroy()
        {
            Destroy(gameObject);
        }
        void OnTriggerEnter(Collider other)
        {
            transform.DOPath(new[] { transform.position, transform.position + new Vector3(-5, -2, 2) }, .8f);
            transform.DOScale(Vector3.one * 1.5f, .8f).SetEase(Ease.OutElastic).OnComplete(Destroy);
        }
    }
}