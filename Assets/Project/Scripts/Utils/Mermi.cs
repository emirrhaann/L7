using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using MainController;
using UnityEngine;

namespace Bullet
{
    public class Mermi : MonoBehaviour
    {
        private Animator animator;
        private GameObject player;
        private PlayerController PlayerController;
        public GameObject Enemy;
        [SerializeField] private float speed;
        
        private void Awake()
        {
            transform.LookAt(new Vector3(PlayerPrefs.GetFloat("enemylocation.x"), 0 ,PlayerPrefs.GetFloat("enemylocation.z")));

            StartCoroutine(nameof(MovementRoutine));
            
        }
        private IEnumerator MovementRoutine()
        {
            while (true)
            {
                transform.position += transform.forward * speed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                yield return new WaitForFixedUpdate();
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(tag = "Enemy"))
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            transform.LookAt(new Vector3(PlayerPrefs.GetFloat("enemylocation.x"), 
                transform.position.y ,
                PlayerPrefs.GetFloat("enemylocation.z")));
            
        }
    }
}