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
    private bool camcontrol;
    // Start is called before the first frame update
    void Start()
    {
        onTriggers = FindObjectOfType<OnTriggers>();
        aradakifark = transform.position - player.transform.position;
    }

    void cameracont()
    {
        transform.DOPath(new[] { transform.position, new Vector3(30.97f, 15.13f, player.transform.position.z) }, 2);
        transform.rotation = Quaternion.Euler(30,90,0);
        cam.fieldOfView = 100;
        camcontrol = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (onTriggers.Passed)
        {
            if (camcontrol== false)
            {
                cameracont();
                transform.position = new Vector3(transform.position.x, transform.position.y, (transform.position.z + player.transform.position.z));
            }
            

        }
        else
        {
            transform.position = player.transform.position + aradakifark;

        }
        
    }
}
