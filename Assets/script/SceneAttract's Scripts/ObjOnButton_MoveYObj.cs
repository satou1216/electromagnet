using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjOnButton_MoveYObj : MonoBehaviour
{

    [SerializeField]
    GameObject obj;


    private void Start()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        obj.GetComponent<MoveLiftY>().enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        obj.GetComponent<MoveLiftY>().enabled = false;
    }

}
