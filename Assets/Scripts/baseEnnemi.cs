using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseEnnemi : MonoBehaviour
{

    public ClassEnnemi behavior;

    // Update is called once per frame
    void Update()
    {
        behavior.PlayBehavior();
    }
}
