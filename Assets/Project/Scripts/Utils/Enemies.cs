using DG.Tweening;
using Project.Scripts.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace Project.Scripts.Utils
{
    public class Enemies : MonoBehaviour
    {
        private PlayerController _playerController;
        public float speed;
        public GameObject reward;
        public bool dead;
        public Animator animator;

        private void Awake()
        {
            _playerController = FindObjectOfType<PlayerController>();
            animator = GetComponent<Animator>();
            transform.LookAt(_playerController.gameObject.transform);
        }
       public void Death()
        {
            animator.CrossFade("DeadAnim", 0.03f);
            dead=true;
            transform.DOScale(Vector3.one * 0, 1f).SetEase(Ease.OutBounce).OnComplete(SpawnReward);
        }

        private void SpawnReward()
        {
            Destroy(gameObject);
            Instantiate(reward, transform.position + new Vector3(0,3,0), Quaternion.Euler(90,0,0));
        }

        private void Update()
        {
            if (dead) return;
                transform.LookAt(_playerController.gameObject.transform.position);
                transform.position += transform.forward * speed;
            
         
        }
    }

}