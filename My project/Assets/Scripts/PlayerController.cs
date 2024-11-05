using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Apple.ReplayKit;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CanvasControl;
using Random = UnityEngine.Random;

namespace MainController
{
    public class PlayerController : MonoBehaviour
    {
        public static bool tapped = false;
        private bool aftertap = false;
        Vector3 mouseposition;
        void Start()
        {
            OnTriggers.restart = false;
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
            var vector3 = transform.position;
            vector3.x = vector3.x + delta.x;
            //transform.position = vector3;
            Debug.Log(delta);
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
            if (aftertap == true && OnTriggers.restart == false && OnTriggers.gameOver == false)
            {
                
                if (mouseposition.x > Screen.width / 2)
                {
                    transform.position = transform.position + transform.right * 0.05f;
                }
                else
                {
                    transform.position = transform.position + transform.right * -0.05f;
                }
            }
           
        }
        private void TapUp()
        {
            Debug.Log("Tap Ended!");
        }
        public void StartMove()
        {
            transform.position = transform.position + transform.forward * 0.1f;
            GetComponent<Animator>().SetFloat("Blend", 0.5f);
        }

        public void Stopmove()
        {
            transform.position = transform.position;
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
            mouseposition = Input.mousePosition;
            if (tapped == true && OnTriggers.restart == false && OnTriggers.gameOver == false)
            {
                StartMove();
                aftertap = true;
                SideMove();
            }
        }
    }
}