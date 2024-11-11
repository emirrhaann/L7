using Project.Scripts.Core;
using Project.Scripts.Utils;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Joystick_Pack.Scripts.Joysticks
{
    public class FloatingJoystick : Joystick
    {
        private Animator _animator;
        private OnTriggers _ontrigger;
        private PlayerController _playerController;
        private bool _pointed;
        protected override void Start()
        {
            _playerController = FindObjectOfType<PlayerController>();
            _ontrigger = FindObjectOfType<OnTriggers>();
            _animator = _playerController.GetComponent<Animator>();
            base.Start();
            background.gameObject.SetActive(false);
  
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
            background.gameObject.SetActive(true);
            base.OnPointerDown(eventData);
            if (_ontrigger.gameOver)
            {
                _animator.CrossFade("Fly", 0.04f);
            }
            else
            {
                _animator.CrossFade("Running", 0.04f);

            }
            _pointed = true;
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            background.gameObject.SetActive(false);
            base.OnPointerUp(eventData);
            if (_ontrigger.gameOver)
            {
                _animator.CrossFade("Fly", 0.04f);
            }
            else
            {
                _animator.CrossFade("Blend Tree", 0.01f);

            }
        
            _pointed = false;
        }

        void FixedUpdate()
        {
            if (_pointed && _ontrigger.gameOver )
            {   
                _playerController.gameObject.transform.position += _playerController.gameObject.transform.forward * .2f;
            }
        }
    }
}