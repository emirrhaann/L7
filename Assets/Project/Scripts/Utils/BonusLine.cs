using System.Collections;
using DG.Tweening;
using Project.Scripts.Core;
using UnityEngine;

namespace Project.Scripts.Utils
{
    public class BonusLine : MonoBehaviour
    {
        public GameObject spawner;
        [SerializeField] private PlayerController playercontroller;
        [SerializeField] private OnTriggers onTriggers;
        [SerializeField] private Camera playerCamera;
        private void ShowGameplay()
        {
            UIManager.Instance.ShowPanel(PanelType.GamePlay);
            onTriggers.bonustext.gameObject.SetActive(false);
        }
        private void ShowBonus()
        {
            UIManager.Instance.HidePanel(PanelType.All);
            onTriggers.bonustext.gameObject.SetActive(true);
            onTriggers.bonustext.transform.DOScale(Vector3.one * 0.7f, 2f).
                SetEase(Ease.OutBounce).OnComplete(ShowGameplay);
        }
        IEnumerator Changing()
        {
            onTriggers.hptext.gameObject.SetActive(false);
            playercontroller.TapInputDisable();
            onTriggers.passed = true;
            ShowBonus();
            playercontroller.animator.CrossFade("VictoryAnimation", 0.1f);
            yield return new WaitForSeconds(2);
            playercontroller.animator.CrossFade("Blend Tree", 0.01f);
            playercontroller.attach.gameObject.SetActive(true);
            onTriggers.joysui.SetActive(true);
            onTriggers.onJoystick = true;
            Instantiate(spawner, new Vector3(62.84f, 0.25f, 2.35f), Quaternion.Euler(0,0,0));
            Destroy(gameObject);
            onTriggers.joysui.SetActive(true);
        }
        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(nameof(Changing));
            playerCamera.transform.DOPath(new []{playerCamera.transform.position, new Vector3(49.8400002f,14.1800003f,0)}, 1f);
           // Cameracont();
        }
        private void Cameracont()
        {
            playerCamera.transform.position = new Vector3(49.8400002f,14.1800003f,0);
        }
    }
}
