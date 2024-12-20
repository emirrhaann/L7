using DG.Tweening;
using Joystick_Pack.Scripts.Joysticks;
using Project.Scripts.Core;
using UnityEngine;
using UnityEngine.UI;


namespace Project.Scripts.Utils
{
    public class FlyLine : MonoBehaviour
    {
        [SerializeField]private OnTriggers onTriggers;
        [SerializeField] private PlayerController playercontroller;
        [SerializeField]private FloatingJoystick floatingJoystick;
        public Text flytext;
        public GameObject finishflag;
        public GameObject coinspawner;
        private void OnTriggerEnter(Collider other)
        {
            if (playercontroller.deadcount >= 3)
            {
                onTriggers.onJoystick = false;
                onTriggers.joysui.gameObject.SetActive(false);
                onTriggers.gameOver = true;
                playercontroller.animator.CrossFadeInFixedTime("VictoryAnimation", 0.5f);
                Destroy(gameObject);
                Destroy(finishflag);
                coinspawner.SetActive(true);
                ShowBonus();
            }
        }
        private void ShowBonus()
        {
            UIManager.Instance.HidePanel(PanelType.All);
            flytext.gameObject.SetActive(true);
            playercontroller.attach.gameObject.SetActive(false);
            flytext.transform.DOScale(Vector3.one * 0.7f, 2f).SetEase(Ease.OutBounce).OnComplete(ShowGameplay);
        }
        private void ShowGameplay()
        {
            playercontroller.rb.useGravity = false;
            flytext.gameObject.SetActive(false);
            onTriggers.onJoystick = true;
            onTriggers.joysui.gameObject.SetActive(true);
            UIManager.Instance.ShowPanel(PanelType.GamePlay);
            floatingJoystick.OnPointerUp(null);
        } 
    }
}