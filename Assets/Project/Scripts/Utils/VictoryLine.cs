using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using MainController;
using UnityEngine;
using UnityEngine.UI;

public class VictoryLine : MonoBehaviour
{
    OnTriggers playerController;
    private PlayerController playerobject;
    private GameObject enemycheck;

    public Text flytext;
    // Start is called before the first frame update
    void Start()
    {
        enemycheck = GameObject.FindGameObjectWithTag("Enemy");
        playerobject = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<OnTriggers>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (enemycheck == null && other.CompareTag("Player"))
        {
            ShowBonus();
            playerController.OnJoystick = false;
            playerController.joysui.gameObject.SetActive(false);
            playerController.gameOver = true;
            playerController.animator.CrossFadeInFixedTime("VictoryAnimation", 0.5f);
            Destroy(gameObject);
        }
        
    }
    private void ShowBonus()
    {
        UIManager.Instance.HidePanel(PanelType.All);
        flytext.gameObject.SetActive(true);
        flytext.transform.DOScale(Vector3.one * 0.7f, 2f).
            SetEase(Ease.OutBounce).OnComplete(ShowGameplay);
    }
    private void ShowGameplay()
    {
        UIManager.Instance.ShowPanel(PanelType.GamePlay);
        flytext.gameObject.SetActive(false);
        playerController.joysui.gameObject.SetActive(true);
        playerController.playerattach.gameObject.SetActive(false);
        playerController.OnJoystick = true;
      // playerobject.rigidbody.isKinematic = true;
        playerobject.rigidbody.useGravity = false;
    }
}
