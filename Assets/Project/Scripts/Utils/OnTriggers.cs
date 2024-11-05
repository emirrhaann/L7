using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DG.Tweening;
using MainController;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;


public class OnTriggers : MonoBehaviour
{
    public GameObject kamera;
    Vector3 mouseposition;
    public int hp;
    public TextMeshProUGUI hptext;
    public TextMeshProUGUI cointext;
    public static int coincount;
    public static int Damage = 20;
    public static bool restart;
    public static bool gameOver;
    private Animator animator;


    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        PlayerPrefs.SetInt("Currentcoin", coincount);
        cointext.text = PlayerPrefs.GetInt("Currentcoin") + "";
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Debuff"))
        {
            if (hp != 0)
            {
                hp -= Damage;
                hptext.text = hp + "";
            }

            if (hp <= 0)
            {
                UIManager.Instance.ShowPanel(PanelType.Lose);

                restart = true;
                animator.CrossFade("DeadAnimation", 0.5f);
            }

            kamera.transform.DOShakeRotation(0.4f, Vector3.one * 0.2f, 90);
        }

        if (other.gameObject.CompareTag("Buff"))
        {
            if (hp != 100)
            {
                hp += 20;
                hptext.text = hp + "";
            }
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            coincount++;
            PlayerPrefs.SetInt("Currentcoin", coincount);
            cointext.text = PlayerPrefs.GetInt("Currentcoin") + "";
        }

        if (hp >= 50)
        {
            hptext.color = Color.green;
        }
        else
        {
            hptext.color = Color.red;
        }

        if (other.gameObject.CompareTag("VictoryLine"))
        {
            UIManager.Instance.ShowPanel(PanelType.Win);
            gameOver = true;
            animator.CrossFadeInFixedTime("VictoryAnimation", 0.5f);
        }
    }
}