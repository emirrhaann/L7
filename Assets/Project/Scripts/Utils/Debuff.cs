using DG.Tweening;
using Project.Scripts.Core;
using UnityEngine;

namespace Project.Scripts.Utils
{
    public class Debuff : MonoBehaviour
    {
        private PlayerController _playerController;
        private OnTriggers _onTriggers;
        private void Start()
        {
            _onTriggers = FindObjectOfType<OnTriggers>();
            _playerController = FindObjectOfType<PlayerController>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (_onTriggers.hp != 0)
            {
                _onTriggers.hp -= _onTriggers.damage;
                _onTriggers.hptext.text = _onTriggers.hp + "";
            }
            if (_onTriggers.hp <= 0)
            {
                UIManager.Instance.ShowPanel(PanelType.Lose);
                _onTriggers.restart = true;
                _playerController.animator.CrossFade("DeadAnimation", 0.5f);
            }
            _onTriggers.kamera.transform.DOShakeRotation(0.4f, Vector3.one * 0.2f, 90);
        }
    }
}
