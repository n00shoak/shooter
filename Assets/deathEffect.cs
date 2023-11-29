using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class deathEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        ps.Play();
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timer > 0.5f) { Destroy(gameObject); }
    }
}
