using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLimit : MonoBehaviour
{
    [SerializeField]
    float x1;
    [SerializeField]
    float x2;
    [SerializeField]
    float y1;
    [SerializeField]
    float y2;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (this.transform.position.x < x1 || x2 < this.transform.position.x || this.transform.position.y < y1 || y2 < this.transform.position.y)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
            transform.position = new Vector3(pos.x, pos.y, pos.z);
        }

    }
}
