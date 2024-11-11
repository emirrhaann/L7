using DG.Tweening;
using Project.Scripts.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Utils
{
    public class VictoryLine : MonoBehaviour
    {
        [SerializeField]private OnTriggers onTriggers;
        [SerializeField] private PlayerController playercontroller;
        public Text flytext;
        private void OnTriggerEnter(Collider other)
        {
            if (playercontroller.deadcount == 3)
            {
                onTriggers.onJoystick = false;
                ShowBonus();
                onTriggers.joysui.gameObject.SetActive(false);
                onTriggers.gameOver = true;
                playercontroller.animator.CrossFadeInFixedTime("VictoryAnimation", 0.5f);
                Destroy(gameObject);
            }
        }
        private void ShowBonus()
        {
            UIManager.Instance.HidePanel(PanelType.All);
            flytext.gameObject.SetActive(true);
            flytext.transform.DOScale(Vector3.one * 0.7f, 2f).SetEase(Ease.OutBounce).OnComplete(ShowGameplay);
        }
        private void ShowGameplay()
        {
            UIManager.Instance.ShowPanel(PanelType.GamePlay);
            flytext.gameObject.SetActive(false);
            onTriggers.joysui.gameObject.SetActive(true);
            onTriggers.playerattach.gameObject.SetActive(false);
            playercontroller.rigidbody.useGravity = false;
            onTriggers.onJoystick = true;
        }
    }
}