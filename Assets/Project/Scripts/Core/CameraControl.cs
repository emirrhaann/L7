using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Vector3 aradakifark;
    OnTriggers onTriggers;
    public GameObject player;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        onTriggers = FindObjectOfType<OnTriggers>();
        aradakifark = transform.position - player.transform.position;
    }

   
    // Update is called once per frame
    void Update()
    {
        if (onTriggers.gameOver)
        {
           
            transform.position = player.transform.position + aradakifark;
            cam.fieldOfView = 60;
            // transform.rotation = player.transform.rotation;

        }
        else
        {
            transform.position = player.transform.position + aradakifark;
        }
        
    }
}
