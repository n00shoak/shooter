using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementEtTir : MonoBehaviour
{

    public Transform limitL;
    public Transform limitR;

    public float Maxspeed;
    public float accel;
    public float deccel;
    float currentSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) )
        {
            if ( currentSpeed > -Maxspeed) { currentSpeed -= accel; }  
        }
        else if (Input.GetKey(KeyCode.RightArrow) )
        {
            if (currentSpeed < Maxspeed) { currentSpeed += accel; }
        }
        else
        {
            if(currentSpeed < -0.5f) { currentSpeed += deccel; }
            else if(currentSpeed > 0.05f) { currentSpeed -= deccel; }
            else if(currentSpeed > -0.5f && currentSpeed < 0.5f) { currentSpeed = 0; }
        }

        transform.position += new Vector3(currentSpeed,0,deccel) * Time.deltaTime;

        if(transform.position.x < limitL.position.x)
        {
            transform.position = new Vector3(limitR.position.x, transform.position.y, 0);
        }
        if (transform.position.x > limitR.position.x)
        {
            transform.position = new Vector3(limitL.position.x, transform.position.y, 0);
        }
    }
}
