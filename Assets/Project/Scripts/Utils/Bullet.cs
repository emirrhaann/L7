using System;
using System.Collections;
using Project.Scripts.Core;
using UnityEngine;

namespace Project.Scripts.Utils
{
    public class Bullet : MonoBehaviour
    {
        private Enemies _enemies;
        private PlayerController _playerController;
        [SerializeField] private float speed;

        private void Start()
        {
            _enemies = FindObjectOfType<Enemies>();
            _playerController = FindObjectOfType<PlayerController>();
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
            if (other.gameObject.CompareTag(tag = "Enemy"))
            {
                _enemies.Death();
                _playerController.deadcount++;
                Destroy(gameObject);
            }
        }
        public void Look(Vector3 lookat)
        {
            transform.LookAt(lookat);
            StartCoroutine(nameof(MovementRoutine));
        }
    }
}