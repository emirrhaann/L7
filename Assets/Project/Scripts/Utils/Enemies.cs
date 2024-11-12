using System;
using System.Collections;
using DG.Tweening;
using Project.Scripts.Core;
using UnityEngine;

namespace Project.Scripts.Utils
{
    public class Enemies : MonoBehaviour
    {
        private PlayerController _playerController;
        public float speed;
        public GameObject reward;
        public bool dead;
        public Animator animator;
        private ParticleSystem _particles;
        private void Awake()
        {
            _particles =  GetComponent<ParticleSystem>();
            _particles.Pause();
            _playerController = FindObjectOfType<PlayerController>();
            animator = GetComponent<Animator>();
            transform.LookAt(_playerController.gameObject.transform);
        }

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(nameof(Death));
        }

        private IEnumerator Death()
        {
            
            animator.CrossFade("DeadAnim", 0.03f);
            dead=true;
            _particles.Play();
            yield return new WaitForSeconds(0.9f);
            _particles.Pause();
            yield return new WaitForSeconds(1.1f);
            Destroy(gameObject);
            Instantiate(reward, transform.position + new Vector3(0,3,0), Quaternion.Euler(90,0,0));
        }
        private void SpawnReward()
        {
           
        }
        private void Update()
        {
            if (dead) return;
                transform.LookAt(_playerController.gameObject.transform.position);
                transform.position += transform.forward * speed;
        }
    }

}