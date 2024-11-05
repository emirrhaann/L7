using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace MainController
{
    public class PlayerController : MonoBehaviour
    {
        private Animator animator;
        public static bool tapped;
        void Start()
        {
            animator = GetComponent<Animator>();
            tapped = false;
            TapInputEnable();
        }
        private void TapInputEnable()
        {
            InputPanel.Instance.OnPointerDownEvent.AddListener(TapDown);
            InputPanel.Instance.OnPointerUpEvent.AddListener(TapUp);
            InputPanel.Instance.OnDragDelta.AddListener(OnDragDelta);
        }
        private void OnDragDelta(Vector2 delta)
        {
            if (delta.x >= 3.98f)
            {
                transform.position += transform.right * 0.15f;
            }
            else
            {
                transform.position += transform.right * -0.15f;
            }
        }
        private void TapInputDisable()
        {
            InputPanel.Instance.OnPointerDownEvent.RemoveListener(TapDown);
            InputPanel.Instance.OnPointerUpEvent.RemoveListener(TapUp);
        }
        private void TapDown()
        {
            if (tapped == false)
            {
                UIManager.Instance.ShowPanel(PanelType.GamePlay);
                
                tapped = true;
            } 
        }
        private void TapUp()
        {
            Debug.Log("Tap Ended!");
        }
        public void StartMove()
        {
            transform.position += transform.forward * 0.1f;
            animator.CrossFadeInFixedTime("Running", 0.2f);
            
        }
        public void SideMove()
        {
            transform.position = new Vector3(transform.position.x,
                transform.position.y,
                Mathf.Clamp(transform.position.z,
                    -2.0f,
                    2.0f)
            );
        }   
        void Update()
        {
            
            if (tapped == true && OnTriggers.restart == false && OnTriggers.gameOver == false)
            {
                StartMove();
            }
            SideMove();
        }
    }
}