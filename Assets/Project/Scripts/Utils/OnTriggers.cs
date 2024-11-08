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
    public int coincount;
    public static int Damage = 20;
    public bool restart;
    public bool gameOver;
    public Animator animator;
    public Text bonustext;
    public bool Passed;
    public GameObject playerattach;
    public bool OnJoystick;
    public GameObject joysui;
    public PlayerController player;



    // Start is called before the first frame update
    private void Awake()
    {
        OnJoystick = false;
        animator = GetComponent<Animator>();
        playerattach = GetComponentInParent<PlayerController>().attach;
        player = GetComponent<PlayerController>();
    }
    private void Start()
    {
        PlayerPrefs.SetInt("Currentcoin", coincount);
        cointext.text = PlayerPrefs.GetInt("Currentcoin") + "";
    }
}