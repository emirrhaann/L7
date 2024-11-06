using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Bullet;


namespace MainController
{
    public class PlayerController : MonoBehaviour
    {
        RaycastHit hit;
        public bool control = false;
        private Animator animator;
        public static bool tapped;
        public GameObject attach;
        public GameObject mermi;

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
            if (tapped == true)
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
        }

        public void StartMove()
        {
            transform.position += transform.forward * 0.1f;
            animator.CrossFade("Running", 0f);
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

        public IEnumerator Attack()
        {
            animator.CrossFade("FireAnim", 0.065f);
            yield return new WaitForSeconds(0.068f);
            Instantiate(mermi, attach.transform.position, attach.transform.rotation);
            animator.CrossFade("Running", 0.65f);
            yield return new WaitForSeconds(2);
            control = false;
        }

       


        void Update()
        {
            Physics.Raycast(new Vector3(transform.position.x,
                transform.position.y + 2,
                transform.position.z), transform.forward * 20, out hit);
            Debug.DrawRay(new Vector3(transform.position.x,
                transform.position.y + 2,
                transform.position.z), transform.forward * 20, Color.blue);
            if (hit.collider != null)
            {
                if (OnTriggers.Passed == true)
                {
                    attach.gameObject.SetActive(true);

                    if (hit.collider.gameObject.CompareTag("Enemy") && control == false)
                    {
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
            SideMove();
        }
    }
}