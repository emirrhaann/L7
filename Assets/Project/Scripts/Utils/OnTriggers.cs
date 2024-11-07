using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DG.Tweening;
using MainController;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UIElements.Image;
using Quaternion = UnityEngine.Quaternion;
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
    public Text bonustext;
    public static bool Passed;
    private GameObject player;
    public GameObject spawner;
    public static bool OnJoystick;
    public GameObject joysui;


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

    private void ShowGameplay()
    {
        UIManager.Instance.ShowPanel(PanelType.GamePlay);
        bonustext.gameObject.SetActive(false);
        
    }

    private void ShowBonus()
    {
        UIManager.Instance.HidePanel(PanelType.All);
        bonustext.gameObject.SetActive(true);
        bonustext.transform.DOScale(Vector3.one * 0.7f, 1.1f).SetEase(Ease.OutBounce).OnComplete(ShowGameplay);
    }

    IEnumerator changing()
    {
        ShowBonus();
        Passed = true;   
        animator.CrossFade("VictoryAnimation", 0.1f);
        yield return new WaitForSeconds(2);
        animator.CrossFade("Blend Tree", 0.1f);
        joysui.SetActive(true);
        OnJoystick = true;
        Instantiate(spawner, new Vector3(32.01f, 0.25f, 2.35f), Quaternion.Euler(0,0,0));
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
            cointext.text = coincount + "";
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
        if (other.gameObject.CompareTag("FinishLine"))
        { 
            StartCoroutine(nameof(changing));
            Destroy(other.gameObject);
            GetComponent<PlayerController>().TapInputDisable();
        }
    }

    
}