using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLimitX : MonoBehaviour
{

    [SerializeField]
    float x1;
    [SerializeField]
    float x2;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (this.transform.position.x < x1 || x2 < this.transform.position.x)
        {
            transform.position = new Vector3(pos.x, pos.y, pos.z);
        }

    }
}
