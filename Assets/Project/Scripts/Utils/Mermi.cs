using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using MainController;
using Project.Scripts.Utils;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

namespace Bullet
{
    public class Mermi : MonoBehaviour
    {
        Enemies Enemies;
        private Animator animator;
        private GameObject player;
        private PlayerController PlayerController;
        [SerializeField] private float speed;

        private void Start()
        {
        }

        private IEnumerator MovementRoutine()
        {
            while (true)
            {
                transform.position += transform.forward * speed * Time.deltaTime;
                yield return new WaitForFixedUpdate();
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            Enemies = other.gameObject.GetComponent<Enemies>();

            if (other.gameObject.CompareTag(tag = "Player"))
            {
                
            }
            else
            {
                Enemies.death();
            }
            Destroy(gameObject);
        }
        public void Look(Vector3 lookat)
        {
            transform.LookAt(lookat);
            StartCoroutine(nameof(MovementRoutine));
        }
    }
}