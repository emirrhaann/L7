using System;
using System.Collections;
using System.Collections.Generic;
using MainController;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    private Animator animator;
private PlayerController playercontroller;
private GameObject player;
    protected override void Start()
    {
playercontroller = FindObjectOfType<PlayerController>();
player = playercontroller.gameObject;
        animator = FindObjectOfType<PlayerController>().GetComponent<Animator>();
        base.Start();
        background.gameObject.SetActive(false);

    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData); 
        animator.CrossFade("Running", 0.04f);
player.transform.position += player.transform.forward;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
        animator.CrossFade("Blend Tree", 0.01f);
    }
}