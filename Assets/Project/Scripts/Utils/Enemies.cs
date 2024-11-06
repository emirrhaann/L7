using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using MainController;
using UnityEngine;
using UnityEditor.UIElements;

public class Enemies : MonoBehaviour
{
    public GameObject player;
    private int enemyhp;

    // Start is called before the first frame update
   

    void Start()
    {
        transform.DOPath(new[] {transform.position, player.transform.position}, 50).SetLoops(-1, LoopType.Restart);
    }

    private void OnTriggerEnter(Collider other)
    {
        enemyhp--;
        if (enemyhp == 0)
        {
            Destroy(gameObject);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
