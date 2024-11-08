using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using MainController;
using Project.Scripts.Utils;
using UnityEngine;

namespace Bullet
{
    public class Mermi : MonoBehaviour
    {
        Enemies Enemies;
        private Animator animator;
        private GameObject player;
        private PlayerController PlayerController;
        public GameObject Enemy;
        [SerializeField] private float speed;

        private void Awake()
        {
            Enemies = FindObjectOfType<Enemies>().GetComponent<Enemies>();
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
            Destroy(gameObject);
            if (other.gameObject.CompareTag(tag = "Enemy"))
            {
                Enemies.enemyhp--;
                if (Enemies.enemyhp <= 0)
                { 
                    StartCoroutine(Enemies.Death());
                }
            }
        }
      /*  IEnumerator Death(Collider other)
        {
            Enemies.dead = true;
            Enemies.animator.CrossFade("DeadAnim", 0.04f);
            yield return new WaitForSeconds(1f);
            Destroy(other.gameObject);
            Instantiate(Enemies.reward, Enemies.drops[0].transform.position, Enemies.reward.transform.rotation);
        }*/
        public void Look(Vector3 lookat)
        {
            transform.LookAt(lookat);
            StartCoroutine(nameof(MovementRoutine));
        }
    }
}