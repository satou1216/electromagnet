using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLimitY : MonoBehaviour
{

    [SerializeField]
    float y1;
    [SerializeField]
    float y2;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pos = this.transform.position;
        pos.y = Mathf.Clamp(this.transform.position.y, y1, y2);
        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}
