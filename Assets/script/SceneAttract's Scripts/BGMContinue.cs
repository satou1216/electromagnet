using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMContinue : MonoBehaviour
{

    // Start is
    //
    // called before the first frame update

    private void Awake()
    {
        int n = FindObjectsOfType<BGMContinue>().Length;



        if(n > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "title" && SceneManager.GetActiveScene().name != "Choice")
        {
            Destroy(gameObject);
        }
    }
}
