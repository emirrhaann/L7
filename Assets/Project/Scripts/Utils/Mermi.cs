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
        [SerializeField] private float speed;


        private void Awake()
        {
            StartCoroutine(nameof(MovementRoutine));
        }


        private IEnumerator MovementRoutine()
        {
            while (true)
            {
                transform.position += transform.right * speed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                yield return new WaitForFixedUpdate();
            }
        }

        void Start()
        {
        }


        /*private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(tag = "Enemy"))
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }*/


        // Update is called once per frame
        void Update()
        {
        }
    }
}