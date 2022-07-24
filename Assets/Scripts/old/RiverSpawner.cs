using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverSpawner : MonoBehaviour
{
    public GameObject River;
    Vector3 nextSpawn;

   public void SpawnRiver()
    {
       GameObject obj = Instantiate(River, nextSpawn, Quaternion.identity);
       nextSpawn = obj.transform.GetChild(1).transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            SpawnRiver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
