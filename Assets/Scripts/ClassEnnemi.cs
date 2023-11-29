using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ClassEnnemi : MonoBehaviour
{
    GameObject target;

    int type;
    int hp;
    float speed;
    float lifeSpan;

    //slither var
    float slither = 0;
    float slRange = 3;
    bool slSwitch = false;
    float count = 0;

    // target var
    float presentation = 0;

    //curve var
    bool LR;

    //stay in the middle var
    float dist = 0;


    public ClassEnnemi(int T , int H, float S , GameObject trg)
    {
        this.target = trg;

        this.type = T;
        this.hp = H;    
        this.speed = S;

        lifeSpan = Time.time;

        Debug.Log(T);

        if(T == 2 || T == 3) { if (Random.Range(0, 2) == 1) this.LR = true; else { LR = false; } target.transform.Rotate(new Vector3(0,0,-100));Debug.Log("CACA"); }

    }

    public void PlayBehavior()
    {
        switch (type)
        {
            case 0:
                typeA(speed);
                break; 

            case 1:
                typeB(speed);
                break;

            case 2:
                typeC(speed);
                typeA(speed);
                break;

            case 3:
                typeD(speed);
                typeA(speed);
                break;

            case 4:
                typeE(speed);
                break;


            default:
                Debug.LogWarning("Error : enemy type out off range");
                break;
        }

        if(Time.time - lifeSpan > 20) { Destroy(target); }
        
    }

    //fall
    void typeA(float speed)
    {
        target.transform.position += -target.transform.up * speed * Time.deltaTime;
    }

    //strage
    void typeB(float speed)
    {
        if(slSwitch) { slither = Mathf.Lerp(slither, slRange, 0.02f); }
        else { slither = Mathf.Lerp(slither, -slRange, 0.02f); }

        if(slither > slRange - 0.1f && slSwitch) { slSwitch = false; }
        if(slither < -slRange + 0.1f && !slSwitch) { slSwitch = true; }

        target.transform.position += new Vector3(slither,-speed,0) * Time.deltaTime;
    }

    //curve
    void typeC(float speed)
    {
        if (LR) {target.transform.Rotate(new Vector3(0,0,speed / 50)); }
        else { target.transform.Rotate(new Vector3(0, 0, -speed / 50)); }
        
    }

    //zigzag
    void typeD(float speed)
    {
        if (slSwitch) { target.transform.Rotate(new Vector3(0, 0, 0.2f * speed)); count += (speed * speed); } // tourne dég de 30° sens horraire
        else { target.transform.Rotate(new Vector3(0, 0, -0.2f * speed)); count -= (speed * speed); ; } // tourne de 30° anti-Horraire

        if(count <= 0) { slSwitch = true; }
        if(count >= 1000 * speed) { slSwitch = false; }

        
    }


    //stay in the middle
    void typeE(float speed)
    {
        if(dist < 2000 / speed)
        {
            target.transform.position += -target.transform.up * Mathf.Lerp(speed, 0, (dist /200)) * Time.deltaTime;
            dist++;
        }
    }
}
