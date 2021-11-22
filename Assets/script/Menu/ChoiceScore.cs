using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChoiceScore : MonoBehaviour
{
    Text t;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Text>();
        if (PlayerPrefs.GetInt("BEST SCORE" + t.name.ToString(), 999) != 999)
        {
            t.text = "ベストスコア："+PlayerPrefs.GetInt("BEST SCORE" + t.name.ToString(), 999).ToString();
        }
        else
        {
            t.enabled = false;
        }

        Result.score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
