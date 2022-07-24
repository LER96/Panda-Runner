using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    Movement movement;
    // Start is called before the first frame update
    //Getting the player's component by finding movement script
    void Start()
    {
        movement = GameObject.FindObjectOfType<Movement>();
    }

    //If player collides with obstacle, destroy player.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name =="Player")
        {
            movement.Death();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
