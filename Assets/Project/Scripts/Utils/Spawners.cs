using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Utils
{
    public class Spawners : MonoBehaviour
    {
        public List<GameObject> spawners = new List<GameObject>();
        [SerializeField]private GameObject mobspawn;
        void Awake()
        {
          //  Instantiate(mobspawn, spawners[4].transform.position, mobspawn.transform.rotation);
          //  Instantiate(mobspawn, spawners[2].transform.position, mobspawn.transform.rotation);
          //  Instantiate(mobspawn, spawners[0].transform.position, mobspawn.transform.rotation); 
            mobspawn.gameObject.tag = "Enemy";
        }
    }
}
