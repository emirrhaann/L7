using System.Collections;
using System.Collections.Generic;
using MainController;
using UnityEngine;

public class VictoryLine : MonoBehaviour
{
    OnTriggers playerController;
    private GameObject playerobject;
    // Start is called before the first frame update
    void Start()
    {
        playerobject = GameObject.FindGameObjectWithTag("Player");
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<OnTriggers>();
    }
    private void OnTriggerEnter(Collider other)
    {
        UIManager.Instance.ShowPanel(PanelType.Win);
        playerController.gameOver = true;
        playerController.animator.CrossFadeInFixedTime("VictoryAnimation", 0.5f);
        playerController.OnJoystick = false;
        playerController.joysui.gameObject.SetActive(false);
    }
}
