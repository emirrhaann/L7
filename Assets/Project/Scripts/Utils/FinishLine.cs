using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using MainController;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject spawner;

    OnTriggers playerController;
    private GameObject playerobject;
    // Start is called before the first frame update
    void Start()
    {
        playerobject = GameObject.FindGameObjectWithTag("Player");
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<OnTriggers>();
    }
    private void ShowGameplay()
    {
        UIManager.Instance.ShowPanel(PanelType.GamePlay);
        playerController.bonustext.gameObject.SetActive(false);
    }

    private void ShowBonus()
    {
        UIManager.Instance.HidePanel(PanelType.All);
        playerController.bonustext.gameObject.SetActive(true);
        playerController.bonustext.transform.DOScale(Vector3.one * 0.7f, 2f).
            SetEase(Ease.OutBounce).OnComplete(ShowGameplay);
    }

    IEnumerator Changing()
    {
        playerController.player.TapInputDisable();
        playerController.Passed = true;
        ShowBonus();
        playerController.animator.CrossFade("VictoryAnimation", 0.1f);
        yield return new WaitForSeconds(2);
        playerController.animator.CrossFade("Blend Tree", 0.01f);
        playerController.playerattach.gameObject.SetActive(true);
        playerController.joysui.SetActive(true);
        playerController.OnJoystick = true;
        Instantiate(spawner, new Vector3(32.01f, 0.25f, 2.35f), Quaternion.Euler(0,0,0));
        Destroy(gameObject);
        playerController.joysui.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(nameof(Changing));
        
    }
}
