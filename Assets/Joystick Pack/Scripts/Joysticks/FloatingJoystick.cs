using System;
using System.Collections;
using System.Collections.Generic;
using MainController;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    private Animator animator;
    OnTriggers ontrigger;
    private GameObject player;
    private bool pointed;
    protected override void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        animator = FindObjectOfType<PlayerController>().GetComponent<Animator>();
        base.Start();
        background.gameObject.SetActive(false);
        ontrigger = FindObjectOfType<OnTriggers>().GetComponent<OnTriggers>();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
        if (ontrigger.gameOver)
        {
            animator.CrossFade("Fly", 0.04f);
        }
        else
        {
            animator.CrossFade("Running", 0.04f);

        }
        pointed = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
        if (ontrigger.gameOver)
        {
            animator.CrossFade("Fly", 0.04f);
        }
        else
        {
            animator.CrossFade("Blend Tree", 0.01f);

        }
        
        pointed = false;
    }

    void FixedUpdate()
    {
        if (pointed && ontrigger.gameOver )
        {   
            player.transform.position += player.transform.forward * .2f;
        }
    }
}