using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MainController;
using UnityEngine.UI;

namespace CanvasControl
{
    public class ChangeLevel : MonoBehaviour
    {
        public void Start()
        {
            PlayerController playerController = GetComponent<PlayerController>();
        }

        public void ChangeScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void GetBuffOne()
        {
            if (OnTriggers.currentcoins >= 5)
            {
                OnTriggers.currentcoins -= 5;
                OnTriggers.playerspeed += 0.01f;

                PlayerPrefs.SetInt("Currentcoin", OnTriggers.currentcoins);
                OnTriggers.coincount = 0;
            }
        }

        public void GetBuffTwo()
        {
            if (OnTriggers.currentcoins >= 8)
            {
                OnTriggers.currentcoins -= 8;
                PlayerPrefs.SetInt("CurrentCoin", OnTriggers.currentcoins);
                OnTriggers.Damage -= 5;
                OnTriggers.coincount = 0;
            }
        }
    }
}