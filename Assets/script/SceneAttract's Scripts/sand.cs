using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sand : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject g;

    MeshRenderer mr;
    Move m;
    void Start()
    {
        m = g.GetComponent<Move>();
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (m.change == true && other.gameObject.tag == "attracted")
        {
            gameObject.SetActive(false);
            Invoke("a",1);
        }
        else if(m.change == false && other.gameObject.tag == "attracted")
        {

            mr.material.color = new Color32(106, 106, 106, 255);
        }
    }

    void a()
    {
        gameObject.SetActive(true);
        mr.material.color = new Color32(106, 106, 106, 135);
    }
}
