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
        Instantiate(mobspawn, spawners[Random.Range(0, spawners.Count)].transform.position, mobspawn.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
