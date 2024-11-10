using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> spawners = new List<GameObject>();
    public GameObject mobspawn;
    void Awake()
    {
        
       // Instantiate(mobspawn, spawners[2].transform.position, mobspawn.transform.rotation);
       // Instantiate(mobspawn, spawners[1].transform.position, mobspawn.transform.rotation);
      //  Instantiate(mobspawn, spawners[0].transform.position, mobspawn.transform.rotation); 
        mobspawn.gameObject.tag = "Enemy";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
