using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using MainController;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class VictoryLine : MonoBehaviour
{
    OnTriggers playerController;
    private PlayerController playerobject;
    private GameObject enemycheck;
    FloatingJoystick joystick;
    public GameObject buts;

    public Text flytext;
    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<FloatingJoystick>();
        enemycheck = GameObject.FindGameObjectWithTag("Enemy");
        playerobject = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<OnTriggers>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (enemycheck == null && other.CompareTag("Player"))
        {
            playerController.OnJoystick = false;
            buts.gameObject.SetActive(false);
            ShowBonus();
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
      // playerobject.rigidbody.isKinematic = true;
        playerobject.rigidbody.useGravity = false;
        playerController.OnJoystick = true;
        buts.gameObject.SetActive(true);


    }
}
