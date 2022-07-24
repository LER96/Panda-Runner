using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverTile : MonoBehaviour
{
    RiverSpawner riverSpawner;
    public GameObject obstaclePF;

    // Start is called before the first frame update
    void Start()
    {
        riverSpawner = GameObject.FindObjectOfType<RiverSpawner>();
        //Invoke("SpawnObstacles" , 1);
        SpawnObstacles();
    }

    private void OnTriggerExit(Collider other)
    {
        riverSpawner.SpawnRiver();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacles()
    {
        int obstacleSpawn = Random.Range(2, 5);
        Transform spawn = transform.GetChild(obstacleSpawn).transform;
        Instantiate(obstaclePF, spawn.position, Quaternion.identity, transform);
    }
}
