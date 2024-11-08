using System.Collections;
using System.Collections.Generic;
using MainController;
using UnityEngine;

public class Coin : MonoBehaviour
{
    OnTriggers playerController;
    private GameObject playerobject;
    // Start is called before the first frame update
    void Start()
    {
        playerobject = GameObject.FindGameObjectWithTag("Player");
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<OnTriggers>();
    }
    private void OnTriggerEnter(Collider other)
    {
        playerController.coincount++;
        playerController.cointext.text = playerController.coincount + "";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
