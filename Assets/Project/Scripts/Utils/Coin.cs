using System;
using System.Collections;
using System.Collections.Generic;
using Project.Scripts.Core;
using Project.Scripts.Utils;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private OnTriggers _onTriggers;
    private PlayerController _playercontroller;
    // Start is called before the first frame update
    private void Start()
    {
        _onTriggers = FindObjectOfType<OnTriggers>();
        _playercontroller = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _onTriggers.coincount++;
        _onTriggers.cointext.text = _onTriggers.coincount + "";
    }
}
