using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using MainController;
using UnityEngine;

public class Buff : MonoBehaviour
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
        if (playerController.hp != 100)
        {
            playerController.hp += 20;
            playerController.hptext.text = playerController.hp + "";
        }
        if (playerController.hp >= 50)
        {
            playerController.hptext.color = Color.green;
        }
        else
        {
            playerController.hptext.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
