using System;
using System.Collections;
using System.Collections.Generic;
using MainController;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    private Animator animator;
    protected override void Start()
    {
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
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
        animator.CrossFade("Blend Tree", 0.01f);
    }
}