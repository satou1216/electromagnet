using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjOnButton_DisappearObj : MonoBehaviour
{
    [SerializeField]
    GameObject obj;


    private void OnTriggerStay(Collider other)
    {
        obj.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        obj.SetActive(true);
    }

}
