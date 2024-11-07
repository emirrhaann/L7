using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using MainController;
using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.Animations;

public class Enemies : MonoBehaviour
{
    public GameObject player;
    private int enemyhp = 3;
    private IEnumerator MovementRoutine()
    {
        while (true)
        {
            transform.position += transform.forward * Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
    void Start()
    {
        transform.LookAt(player.transform);

        StartCoroutine(nameof(MovementRoutine));
    }

    private void OnTriggerEnter(Collider other)
    {
        enemyhp--;
        if (enemyhp == 0)
        {
            Destroy(gameObject);
        }
    }

    void lateupdate()
    {
        transform.LookAt(player.transform);

    }
}
