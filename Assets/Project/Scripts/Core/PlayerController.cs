using System.Collections;
using Joystick_Pack.Scripts.Joysticks;
using Project.Scripts.Utils;
using UnityEngine;

namespace Project.Scripts.Core
{
    public class PlayerController : MonoBehaviour
    {
        public float firstarealimitmin;
        public float firstarealimitmax;
        public float secondarealimitmin;
        public float secondarealimitmax;
        private RaycastHit _hit;
        public bool control;
        public Animator animator;
        private bool _tapped;
        public GameObject attach;
        public Bullet spawnbullet;
        public bool pas;
        public FloatingJoystick floatingJoystick;
        [SerializeField]private OnTriggers onTriggers;
        public int deadcount;
        public Rigidbody rb;
        [SerializeField] public float flyspeed;
        [SerializeField] private Camera playerCamera;

        private void Awake()
        { 
            TapInputEnable();
           animator = GetComponent<Animator>();
           rb = GetComponent<Rigidbody>();
        }
        private void TapInputEnable()
        {
            InputPanel.Instance.OnPointerDownEvent.AddListener(TapDown);
            InputPanel.Instance.OnDragDelta.AddListener(OnDragDelta);
        }
        private void OnDragDelta(Vector2 delta)
        {
            if (!_tapped || pas || onTriggers.restart) return;
            if (delta.x >= 3.98f)
            {
                transform.position += transform.right * 0.15f;
            }
            else
            {
                transform.position += transform.right * -0.15f;
            }
        }
        public void TapInputDisable()
        {
            InputPanel.Instance.OnPointerDownEvent.RemoveListener(TapDown);
            InputPanel.Instance.OnDragDelta.RemoveListener(OnDragDelta);
            pas = true;
        }
        private void TapDown()
        {
            if (_tapped) return;
            UIManager.Instance.ShowPanel(PanelType.GamePlay);
            onTriggers.hptext.gameObject.SetActive(true);
            _tapped = true;
        }

        private void StartMove()
        {
            transform.position += transform.forward * 0.1f;
            animator.CrossFade("Running", 0f);
        }

        private void SideMove()
        {
            if (onTriggers.passed == false)
            {
                transform.position = new Vector3(transform.position.x,
                    transform.position.y,
                    Mathf.Clamp(transform.position.z,
                        firstarealimitmin,
                        firstarealimitmax)
                );
            }
            else
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, 61.6f, 85.6f),
                    transform.position.y,
                    Mathf.Clamp(transform.position.z,
                        secondarealimitmin,
                        secondarealimitmax)
                );
            }

            if (onTriggers.gameOver)
            {
                
            }
        
        }

        private IEnumerator Attack(Vector3 target)
        {
            animator.CrossFade("FireAnim", 0.04f);
            yield return new WaitForSeconds(0.05f);
            animator.CrossFade("Running", 0.04f);
            var bullet = Instantiate(spawnbullet, attach.transform.position, attach.transform.rotation);
            bullet.Look(target);
            yield return new WaitForSeconds(1.5f);
            control = false;
        }

        private void Update()
        {
            if (onTriggers.gameOver == false)
            {
                
                SideMove();
            }
            else
            {
                transform.position = new Vector3(transform.position.x,
                    Mathf.Clamp(transform.position.y, .2f,10),
                    transform.position.z);
            }
            Physics.Raycast(new Vector3(transform.position.x,
                transform.position.y + 2,
                transform.position.z), transform.forward * 20, out _hit); 
            if (_hit.collider)
            {
                if (onTriggers.passed)
                {
                    if (_hit.collider.gameObject.CompareTag("Enemy") && control == false && onTriggers.onJoystick)
                    {
                        StartCoroutine(Attack(_hit.collider.gameObject.transform.position + new Vector3(0,2,0)));
                        control = true;
                    }
                }
            }
            if (_tapped&& onTriggers.restart == false && onTriggers.gameOver == false &&
                onTriggers.passed == false)
            {
                StartMove();
            }
        }
        private void FixedUpdate()
        {
            if (onTriggers.onJoystick && onTriggers.gameOver == false)
            {
                Vector3 direction = Vector3.right * floatingJoystick.Vertical +
                                    Vector3.forward * -floatingJoystick.Horizontal;
                if (direction.x != 0 && direction.z != 0)
                {
                    PlayerPrefs.SetFloat("direction.x", floatingJoystick.Vertical);
                    PlayerPrefs.SetFloat("direction.z", floatingJoystick.Horizontal);
                }
                transform.position += (direction * 0.14f);
                direction.x += 0.25f;
                transform.rotation = Quaternion.LookRotation((new Vector3(PlayerPrefs.GetFloat("direction.x"), 
                    direction.y,
                    -PlayerPrefs.GetFloat("direction.z"))));

            }
    
            if (!onTriggers.onJoystick || !onTriggers.gameOver) return;
            {
                Vector3 direction = Vector3.up * floatingJoystick.Vertical +
                                    Vector3.forward * -floatingJoystick.Horizontal;
                transform.position += (direction * flyspeed);
                direction.y +=5;
                transform.rotation.SetLookRotation(direction);
                transform.rotation = new Quaternion(direction.x,
                  direction.y, 
                    direction.z, 5);    
            }   
        }
    }
}