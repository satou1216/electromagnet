using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{ 

    [SerializeField]
    GameObject player;

   public static bool pointflag;

    // Start is called before the first frame update
    void Start()
    {
        if (pointflag==true)
        {
            player.transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        pointflag = true;
        GetComponent<Renderer>().material.color = Color.red;

    }

}
