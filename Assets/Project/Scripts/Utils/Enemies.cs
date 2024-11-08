using System.Collections;
using System.Collections.Generic;
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
 
        void Awake()
        {
            animator = GetComponent<Animator>();
            player = GameObject.FindGameObjectWithTag("Player");
            transform.LookAt(player.transform);
        }
       public IEnumerator Death()
        {
            dead = true;
            animator.CrossFade("DeadAnim", 0.03f);
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
            Instantiate(reward, drops[0].transform.position, reward.transform.rotation);
        }
        void Update()
        {
            if (dead == false)
            {
                transform.LookAt(player.transform);
                transform.position += transform.forward * speed;
            }
        }
    }

}