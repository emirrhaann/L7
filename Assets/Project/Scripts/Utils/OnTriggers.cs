using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;


namespace Project.Scripts.Utils
{
    public class OnTriggers : MonoBehaviour
    {
        public GameObject kamera;
        Vector3 _mouseposition;
        public int hp;
        public TextMeshProUGUI hptext;
        public TextMeshProUGUI cointext;
        public int coincount;
        public int damage = 20;
        public bool restart;
        public bool gameOver;
        public Animator animator;
        public Text bonustext;
        public bool passed;
        public GameObject playerattach;
        public bool onJoystick;
        public GameObject joysui;

        private void Awake()
        {
            passed = false;
            onJoystick = false;
            animator = GetComponent<Animator>();
        }
        private void Start()
        {
            PlayerPrefs.SetInt("Currentcoin", coincount);
            cointext.text = PlayerPrefs.GetInt("Currentcoin") + "";
        }

        private void Update()
        {

        }
    }
}