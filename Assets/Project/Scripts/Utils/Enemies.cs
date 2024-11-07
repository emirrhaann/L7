using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using MainController;
using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.Animations;
using Random = System.Random;

public class Enemies : MonoBehaviour
{
    private GameObject player;
    private int enemyhp = 1;
    public float speed;
    Animator animator;
    public List<GameObject> drops = new List<GameObject>();
    public GameObject reward;

    private bool dead;
    /*private IEnumerator MovementRoutine()
    {
        while (true)
        {
            
            yield return new WaitForFixedUpdate();
        }
    }*/
    void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform);

    }

    private void OnTriggerEnter(Collider other)
    {
        enemyhp--;
        if (enemyhp == 0)
        {
            StartCoroutine(nameof(Death));
        }
    }

    IEnumerator Death()
    {
        dead = true;
        animator.CrossFade("DeadAnim", 0.04f);
        yield return new WaitForSeconds(2.3f);
        Destroy(gameObject);
        Instantiate(reward, drops[0].transform.position, reward.transform.rotation);
        Instantiate(reward, drops[1].transform.position, reward.transform.rotation);
        Instantiate(reward, drops[2].transform.position, reward.transform.rotation);
        Instantiate(reward, drops[3].transform.position, reward.transform.rotation);



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
