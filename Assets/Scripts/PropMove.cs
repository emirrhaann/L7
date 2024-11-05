using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropMove : MonoBehaviour
{

    IEnumerator WaitForIt()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 180f);

        yield return new WaitForSeconds(3);
        
    }

    void Update()
    {
       /* transform.position = new Vector3(0.5510653f,
            Random.Range(7.5f, 8.5f),
            -5.69f);
        WaitForIt();*/
    }
}
