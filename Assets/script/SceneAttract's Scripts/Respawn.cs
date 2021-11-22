using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    [SerializeField]
    private float y;
    private Vector3 pos;

    RetryByKey r;

    private void Start()
    {
        r = GetComponent<RetryByKey>();
    }

    void Update()
    {
        pos = GameObject.Find("Player").transform.position;
        if (pos.y < y)
        {
            r.retry();
        }
    }
}
