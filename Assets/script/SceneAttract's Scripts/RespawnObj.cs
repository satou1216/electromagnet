using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObj : MonoBehaviour
{
    private Vector3 pos;
    private bool respawn;
    private float respawnTime;

    [SerializeField]
    float t = 1;

    // Start is called before the first frame update
    void Start()
    {
        pos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (respawn)
        {
            respawnTime += Time.deltaTime;
        }
        
        if(respawnTime > t)
        {
            gameObject.transform.position = pos;
        }

    }

    private void OnBecameInvisible()
    {
        respawn = true;
    }
}
