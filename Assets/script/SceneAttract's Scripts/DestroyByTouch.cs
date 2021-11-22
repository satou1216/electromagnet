using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTouch : MonoBehaviour
{
    [SerializeField]
    GameObject obj;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == obj)
        {
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
