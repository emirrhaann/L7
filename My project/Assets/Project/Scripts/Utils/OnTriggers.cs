using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnTriggers : MonoBehaviour
{
    public static float playerspeed = 0.02f;
    Vector3 mouseposition;
    public int hp;
    public TextMeshProUGUI hptext;
    public TextMeshProUGUI deathtext;
    public TextMeshProUGUI wintext;
    public TextMeshProUGUI cointext;
    public TextMeshProUGUI reloadtext;
    public static int coincount;
    public static int Damage = 50;
    public static int currentcoins;
    public static bool restart;
    public static bool gameOver;


    // Start is called before the first frame update
 void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Debuff"))
            {
                if (hp != 0)
                {
                    hp = hp - Damage;
                    hptext.text = hp + " HP";
                }

                if (hp <= 0)
                {
                    UIManager.Instance.ShowPanel(PanelType.Lose);

                    restart = true;
                    GetComponent<Animator>().CrossFadeInFixedTime("DeadAnimation", 00);
                }
            }

            if (other.gameObject.CompareTag("Buff"))
            {
                if (hp != 100)
                {
                    hp = hp + 20;
                    hptext.text = hp + " HP";
                }
            }

            if (other.gameObject.CompareTag("Coin"))
            {
                coincount++;


                cointext.text = PlayerPrefs.GetInt("Currentcoin") + coincount + "";
                currentcoins = PlayerPrefs.GetInt("Currentcoin") + coincount;
            }

            if (hp >= 50)
            {
                hptext.color = Color.green;
            }
            else
            {
                hptext.color = Color.red;
            }

            if (other.gameObject.CompareTag("VictoryLine") || other.gameObject.CompareTag("Level2Line"))
            {
                UIManager.Instance.ShowPanel(PanelType.Win);
                gameOver = true;
                GetComponent<Animator>().CrossFadeInFixedTime("VictoryAnimation", 0.5f);
            }
        }
}
