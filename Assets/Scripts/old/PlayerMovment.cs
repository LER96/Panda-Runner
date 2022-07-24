using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5;
    public float smoothturn = 0.1f;
    public Transform cam;
    private float smoothV;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += Vector3.forward * speed * Time.deltaTime; ;
        float horizontal = Input.GetAxisRaw("Horizontal"); // up or down arrow, W or S keys
        Vector3 direction = new Vector3(horizontal, 0f, speed).normalized;

        if(direction.magnitude>=0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; // an factor that create an angle between x and the 0 point (player position)
            float agnle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothV, smoothturn);
            transform.rotation = Quaternion.Euler(0f, agnle, 0f);

            Vector3 movedir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(movedir.normalized * speed * Time.deltaTime);
        }
    }
}
