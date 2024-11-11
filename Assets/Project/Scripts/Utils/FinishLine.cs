using System.Collections;
using DG.Tweening;
using Project.Scripts.Core;
using UnityEngine;

namespace Project.Scripts.Utils
{
    public class FinishLine : MonoBehaviour
    {
        public GameObject spawner;
        [SerializeField] private PlayerController playercontroller;
        [SerializeField] private OnTriggers onTriggers;
        
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
            Instantiate(spawner, new Vector3(32.01f, 0.25f, 2.35f), Quaternion.Euler(0,0,0));
            Destroy(gameObject);
            onTriggers.joysui.SetActive(true);
        }
        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(nameof(Changing));
            Cameracont();
            transform.position = new Vector3(transform.position.x, transform.position.y, (transform.position.z + onTriggers.transform.position.z));
        
        }
        private void Cameracont()
        {
            transform.DOPath(new[] { transform.position, new Vector3(30.97f, 15.13f, onTriggers.transform.position.z) }, 2);
            transform.rotation = Quaternion.Euler(30,90,0);
            Camera.main.fieldOfView = 100;
        
        }
    }
}
