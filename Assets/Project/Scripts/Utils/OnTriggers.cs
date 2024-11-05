using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using MainController;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;
using UnityEngine.UI;


public class OnTriggers : MonoBehaviour
{
    Vector3 mouseposition;
    public int hp;
    public TextMeshProUGUI hptext;
    public TextMeshProUGUI deathtext;
    public TextMeshProUGUI wintext;
    public TextMeshProUGUI cointext;
    public TextMeshProUGUI reloadtext;
    public static int coincount;
    public static int Damage = 20;
    public static int currentcoins;
    public static bool restart;
    public static bool gameOver;
    public Image buffreact;
    public Image debuffreact;
    public Image coinreact;



    // Start is called before the first frame update

    private void Start()
    {
        PlayerPrefs.SetInt("Currentcoin", coincount);
        cointext.text = PlayerPrefs.GetInt("Currentcoin") + "";
    }

    
    private IEnumerator BuffReact()
    {
        yield return new WaitForSeconds(0.1f);
        var color = buffreact.color;
        color.a = 0.03f;
        buffreact.color = color;
        yield return new WaitForSeconds(0.1f);
        color.a = 0;
        buffreact.color = color;
    }
    private IEnumerator DeBuffReact()
    {
        yield return new WaitForSeconds(0.1f);
        var color = debuffreact.color;
        color.a = 0.07f;
        debuffreact.color = color;
        yield return new WaitForSeconds(0.1f);
        color.a = 0;
        debuffreact.color = color;
    }
    private IEnumerator CoinReact()
    {
        yield return new WaitForSeconds(0.1f);
        var color = coinreact.color;
        color.a = 0.01f;
        coinreact.color = color;
        yield return new WaitForSeconds(0.1f);
        color.a = 0;
        coinreact.color = color;
    }

   
   

    void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Debuff"))
            {
                if (hp != 0)
                {
                    hp -= Damage;
                    hptext.text = hp + " HP";
                }

                if (hp <= 0)
                {
                    UIManager.Instance.ShowPanel(PanelType.Lose);
                    
                    restart = true;
                    GetComponent<Animator>().CrossFadeInFixedTime("DeadAnimation", 00);
                }
                other.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
               
               StartCoroutine(DeBuffReact());
               Destroy(other.transform.parent.gameObject, 0.1f);
                
            }

            if (other.gameObject.CompareTag("Buff"))
            {
                if (hp != 100)
                {
                    hp += 20;
                    hptext.text = hp + " HP";
                }
                other.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
               
                StartCoroutine(BuffReact());
                Destroy(other.transform.parent.gameObject, 0.1f);
            }

            if (other.gameObject.CompareTag("Coin"))
            {
                coincount++;
                PlayerPrefs.SetInt("Currentcoin", coincount);
                cointext.text = PlayerPrefs.GetInt("Currentcoin") + "";
                other.transform.DOMove(other.transform.position + new Vector3(other.transform.position.x,
                    other.transform.position.y + 2f,
                    other.transform.position.z), 0.5f).SetEase(Ease.OutBounce);
                    
                                       
               
               transform.DOKill();
               StartCoroutine(CoinReact());
               // Destroy(other.transform.parent.gameObject, 0.1f)
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
                GetComponent<Animator>().CrossFadeInFixedTime("VictoryAnimation", 0.5f);
            }
        }

}
