using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tir : MonoBehaviour
{
    public GameObject bullet;
    public Transform parent;
    public scorePlayer sc;

    public float attackSpeed;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {   
            if(Time.time - timer > attackSpeed ) 
            {
                GameObject piou =  Instantiate(bullet, parent.position, parent.rotation);
                Bullet data = piou.GetComponent<Bullet>();
                data.score = sc;
                timer = Time.time;
            }
        }
    }
}
