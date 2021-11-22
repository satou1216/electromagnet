using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerastop2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -2.5)
        {
            this.transform.parent = null;
        }
    }
}
