using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{ 
    [SerializeField]
    float vanishTime = 2;
    [SerializeField]
    float firstVanish = 0;
    float vanish = 0;
    [SerializeField]
    float activeTime = 1;
    [SerializeField]
    float firstActive = 0;
    float active = 0;

    private bool on;


// Start is called before the first frame update
    void Start()
    {
        vanish = firstVanish;
        active = firstActive;
        on = false;
    }

// Update is called once per frame
    void Update()
    {
        if (!on)
        {
            vanish += Time.deltaTime;
            if (vanish > vanishTime)
            {
                vanish = 0;
                this.gameObject.GetComponent<ParticleSystem>().Play(true);
                on = true;
            }

        }

        if (on)
        {
            active += Time.deltaTime;
            if (active > activeTime)
            {
                active = 0;
                this.gameObject.GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);
                on = false;
            }
        }



    }
}