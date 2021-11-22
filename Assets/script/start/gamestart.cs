using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamestart : MonoBehaviour
{
    private void Start()
    {
        //sPlayerPrefs.DeleteAll();
    }

    public void Update()
    {
        
    }

   public void start()
    {
        SceneManager.LoadScene("Choice");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }

}