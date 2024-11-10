using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Project.Scripts.Utils
{
    
    public class Enemies : MonoBehaviour
    {
        private GameObject player;
        public int enemyhp = 1;
        public float speed;
        public Animator animator;
        public List<GameObject> drops = new List<GameObject>();
        public GameObject reward;
        public bool dead;
 
        void Start()
        {
            animator = GetComponent<Animator>();
            player = GameObject.FindGameObjectWithTag("Player");
            transform.LookAt(player.transform);
        }

       public void death()
        {
            animator.CrossFade("DeadAnim", 0.03f); 
            dead = true;
            transform.DOScale(Vector3.zero * 0, 2f).SetEase(Ease.InOutBack).OnComplete(spawnreward);
        }

        void spawnreward()
        {
            Destroy(gameObject);
            Instantiate(reward, transform.position + new Vector3(0,3,0), Quaternion.Euler(90,0,0));

        }
        void Update()
        {
            if (dead == false)
            {
                transform.LookAt(player.transform);
                transform.position += transform.forward * speed;
            }
            else
            {
            }
        }
    }

}