using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject deathEff;
    public Rigidbody2D monRigidBody;
    public float speed;
    public scorePlayer score;

    // Start is called before the first frame update
    void Start()
    {
        monRigidBody.velocity = Vector3.up*speed;
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(deathEff,transform.position , transform.rotation);
        score.addScore(10);
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }

}
