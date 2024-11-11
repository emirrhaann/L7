using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Project.Scripts.Core;
using Project.Scripts.Utils;
using UnityEngine;
using UnityEngine.Serialization;

public class Buff : MonoBehaviour
{
    private OnTriggers _onTriggers;
    private PlayerController _playercontroller;

    private void Start()
    {
        _onTriggers = FindObjectOfType<OnTriggers>();
        _playercontroller = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_onTriggers.hp != 100)
        {
            _onTriggers.hp += 20;
            _onTriggers.hptext.text = _onTriggers.hp + "";
        }
        if (_onTriggers.hp >= 50)
        {
            _onTriggers.hptext.color = Color.green;
        }
        else
        {
            _onTriggers.hptext.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
