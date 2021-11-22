using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject obj;

    [SerializeField]
    AudioSource a;

    private void OnTriggerEnter(Collider other)
    {
        a.PlayOneShot(a.clip);
    }


    private void OnTriggerStay(Collider other)
    {
        obj.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        obj.SetActive(true);
    }

}
