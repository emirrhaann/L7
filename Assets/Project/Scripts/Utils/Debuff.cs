using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using MainController;
using UnityEngine;

public class Debuff : MonoBehaviour
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
        if (playerController.hp != 0)
        {
            playerController.hp -= OnTriggers.Damage;
            playerController.hptext.text = playerController.hp + "";
        }

        if (playerController.hp <= 0)
        {
            UIManager.Instance.ShowPanel(PanelType.Lose);
            playerController.restart = true;
            playerController.animator.CrossFade("DeadAnimation", 0.5f);
        }

        playerController.kamera.transform.DOShakeRotation(0.4f, Vector3.one * 0.2f, 90);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
