using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Prefab;
    public scorePlayer scale;
    public float Difficulty;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //difficulty scaling
        float difscale =  (scale.playerScore / 100 * (Difficulty / 50)) * Difficulty;
        if(difscale > 10 ) { difscale = 10; }

        if (Time.time - timer > (10 -difscale) + 1)
        {
            spawnFoe(Mathf.RoundToInt(Random.Range(0, difscale / 2)), 1,difscale + 1f, Mathf.RoundToInt(Random.Range(1,1+difscale)),1);
            Debug.Log("SPAWN  " + difscale);

            timer = Time.time;
        }
    }

    void spawnFoe(int Type , int Hp , float Speed , int flok , float flokSpace  )
    {
        float rndpos = Random.Range(8, -8);
        for (int i = 0; i< flok;i++)
        {
            GameObject foe = Instantiate(Prefab[Type], new Vector3(rndpos, 5 + flokSpace * i, 0), Quaternion.Euler(0, 0, 0));
            ClassEnnemi mechant = new ClassEnnemi(Type, Hp, Speed, foe);
            baseEnnemi setBehavior = foe.GetComponent<baseEnnemi>();
            setBehavior.behavior = mechant;
        }
    }
}
