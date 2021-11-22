using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    // public Text highScoreText; //ハイスコアを表示するText

    Move move;

    [SerializeField]
    GameObject panel;

    private int highScore; //ハイスコア用変数
    public static int score=0;
    private static string stagecount;
    private string key = "BEST SCORE"; //ハイスコアの保存先キー


    // Start is called before the first frame update
    void Start()
    {
        stagecount = SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 1);
        key += stagecount;
        highScore = PlayerPrefs.GetInt(key, 999);
        move = GameObject.Find("Player").GetComponent<Move>();
       // score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void input()
    {
        if (SceneManager.GetActiveScene().name=="Stage1") {
            panel.SetActive(false);
        }

        if (highScore > score)
        {
            highScore = score;
            move.t2.text = "ベストスコア更新 !\n今回のリセット回数：" + score.ToString();
            PlayerPrefs.SetInt(key, highScore);

        }
        else
        {
            move.t2.text = " 今回のリセット回数：" + score.ToString();
        }
    }

}
