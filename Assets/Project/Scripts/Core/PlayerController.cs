using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Bullet;
using UnityEngine.UIElements;


namespace MainController
{
    public class PlayerController : MonoBehaviour
    {
        public RaycastHit hit;
        public bool control = false;
        public Animator animator;
        public static bool tapped;
        public GameObject attach;
        public GameObject mermi;
        public bool pas;
        public FloatingJoystick floatingJoystick;
        public Rigidbody rb;

        void Awake()
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
            if (tapped == true && pas == false)
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
        }
        public void TapInputDisable()
        {
            InputPanel.Instance.OnPointerDownEvent.RemoveListener(TapDown);
            InputPanel.Instance.OnPointerUpEvent.RemoveListener(TapUp);
            InputPanel.Instance.OnDragDelta.RemoveListener(OnDragDelta);
            pas = true;
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
        }
        public void StartMove()
        {
            transform.position += transform.forward * 0.1f;
            animator.CrossFade("Running", 0f);
        }
        public void SideMove()
        {
            if (OnTriggers.Passed == false)
            {
                transform.position = new Vector3(transform.position.x,
                    transform.position.y,
                    Mathf.Clamp(transform.position.z,
                        -2.0f,
                        2.0f)
                );
            }
            else
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, 41.4f, 57f),
                    transform.position.y,
                    Mathf.Clamp(transform.position.z,
                        -10.5f,
                        10.5f)
                );
            }
            
        }
        public IEnumerator Attack()
        {
            animator.CrossFade("FireAnim", 0.04f);
            yield return new WaitForSeconds(0.05f);
            animator.CrossFade("Running", 0.04f);
            Instantiate(mermi, attach.transform.position, attach.transform.rotation);
            yield return new WaitForSeconds(1);
            control = false;
        }
        void Update()
        {
            SideMove();
            Physics.Raycast(new Vector3(transform.position.x,
                transform.position.y + 2,
                transform.position.z), transform.forward * 20, out hit);
            Debug.DrawRay(new Vector3(transform.position.x,
                transform.position.y + 2,
                transform.position.z), transform.forward * 20);
            if (hit.collider != null)
            {
                if (OnTriggers.Passed == true)
                {
                    attach.gameObject.SetActive(true);
                    if (hit.collider.gameObject.CompareTag("Enemy") && control == false && OnTriggers.OnJoystick)
                    {
                        PlayerPrefs.SetFloat("enemylocation.x", hit.collider.gameObject.transform.position.x);
                        PlayerPrefs.SetFloat("enemylocation.z", hit.collider.gameObject.transform.position.z);
                        StartCoroutine(nameof(Attack));
                        control = true;
                    }
                }
            }
            if (tapped == true && OnTriggers.restart == false && OnTriggers.gameOver == false &&
                OnTriggers.Passed == false)
            {
                StartMove();
            }
        }
        void FixedUpdate()
        {
            if (OnTriggers.OnJoystick)
            {
                Vector3 direction = Vector3.right * floatingJoystick.Vertical +
                                    Vector3.forward * -floatingJoystick.Horizontal;
                transform.position += (direction * 0.14f);
                direction.x += 0.25f;
                transform.rotation = Quaternion.LookRotation(direction);
                
            }
        }
    }
}