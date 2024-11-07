using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Vector3 aradakifark;

    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        aradakifark = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + aradakifark;
        
        

    }
}
