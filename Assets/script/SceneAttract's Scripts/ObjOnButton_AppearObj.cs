using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjOnButton_AppearObj : MonoBehaviour
{

    [SerializeField]
    GameObject obj;


    private void OnTriggerStay(Collider other)
    {
        obj.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        obj.SetActive(false);
    }

}