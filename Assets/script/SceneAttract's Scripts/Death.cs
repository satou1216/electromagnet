using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    RetryByKey r;

    private void Start()
    {
        r = GameObject.Find("RetryObj").GetComponent<RetryByKey>();
    }

    private void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "attracted")
        {
            GameObject.FindGameObjectWithTag("Flame").GetComponent<AudioSource>().PlayOneShot(GameObject.FindGameObjectWithTag("Flame").GetComponent<AudioSource>().clip);
            r.Invoke("a",0.4f);
        }
    }

}
