using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryByKey : MonoBehaviour
{
    bool b;

    private void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            a();
        }
    }

    public void retry()
    {
        if (b == false)
        {
            GameObject.FindGameObjectWithTag("attracted").GetComponents<AudioSource>()[5].PlayOneShot(GameObject.FindGameObjectWithTag("attracted").GetComponents<AudioSource>()[5].clip);
            Invoke("a", 0.3f);
            b = true;
        }
       
    }

    public void a()
    {
        Result.score++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
