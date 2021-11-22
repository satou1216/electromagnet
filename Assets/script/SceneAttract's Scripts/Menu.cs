using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    bool pause;
    bool check;

    [SerializeField]
    GameObject obj;
    [SerializeField]
    GameObject obj2;
    [SerializeField]
    GameObject obj3;
    [SerializeField]
    GameObject e;
    [SerializeField]
    Button backButton;
    [SerializeField]
    Button closeExplanationButton;
    [SerializeField]
    Button yesButton;
    [SerializeField]
    Button noButton;
    [SerializeField]
    Button stageSelectButton;
    

    int select;
    bool yes;
    [SerializeField]
    Text t;

   public AudioClip move,decision;

    RetryByKey r;
    AudioSource[] a;
    AudioSource[] b;
    Move m;
    

    // Start is called before the first frame update
    void Start()
    {
        pause = false;
        check = false;
        select = 0;
        yes = true;

        r = GameObject.Find("RetryObj").GetComponent<RetryByKey>();
        a = GameObject.Find("RetryObj").GetComponents<AudioSource>();
        b = GameObject.Find("Player").GetComponents<AudioSource>();
        m = GameObject.Find("Player").GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {




        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            if (!check && !e.activeSelf)
            {
                backButton.Select();
                select = 0;
            }
            else if (check)
            {
                yesButton.Select();
                yes = true;
            }
            else if (e.activeSelf)
                closeExplanationButton.Select();
        }


        if ((Input.GetKeyDown(KeyCode.M)) && !pause && !m.rock)
        {
            GetComponent<AudioSource>().PlayOneShot(decision);
            obj.SetActive(true);
            obj3.SetActive(true);
            stageSelectButton.Select();
            backButton.Select();
            pause = true;
            m.GetComponent<Move>().enabled = false;
            a[0].Pause();
            a[1].Pause();
            b[1].Stop();
            b[4].Stop();
            Time.timeScale = 0;

        }
        else if ((Input.GetKeyDown(KeyCode.M)) && pause && !check)
        {
            GetComponent<AudioSource>().PlayOneShot(decision);
            obj.SetActive(false);
            obj2.SetActive(false);
            e.SetActive(false);
            pause = false;
            yes = true;
            select = 0;
            a[0].UnPause();
            a[1].UnPause();
            m.GetComponent<Move>().enabled = true;
            Time.timeScale = 1;
        }
        else if ((Input.GetKeyDown(KeyCode.M)) && pause && check)
        {
            GetComponent<AudioSource>().PlayOneShot(decision);
            obj.SetActive(false);
            obj2.SetActive(false);
            pause = false;
            check = false;
            yes = true;
            select = 0;
            a[0].UnPause();
            a[1].UnPause();
            m.GetComponent<Move>().enabled = true;
            Time.timeScale = 1;
        }



        if (check && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && yes == true)
        {
            GetComponent<AudioSource>().PlayOneShot(move);
            yes = false;
        }
        else if (check && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && yes == false)
        {
            GetComponent<AudioSource>().PlayOneShot(move);
            yes = true;
        }
        else if (check && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && yes == true)
        {
            GetComponent<AudioSource>().PlayOneShot(move);
            yes = false;
            noButton.Select();
        }
        else if (check && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && yes == false)
        {
            GetComponent<AudioSource>().PlayOneShot(move);
            yes = true;
            yesButton.Select();
        }

        if (pause && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && select < 3 && !check)
        {
            GetComponent<AudioSource>().PlayOneShot(move);
            select += 1;
        }
        else if (pause && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && select > 0 && !check)
        {
            GetComponent<AudioSource>().PlayOneShot(move);
            select -= 1;
        }
        else if (pause && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && select == 3 && !check)
        {
            GetComponent<AudioSource>().PlayOneShot(move);
            select = 0;
            backButton.Select();
        }
        else if (pause && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && select == 0 && !check)
        {
            GetComponent<AudioSource>().PlayOneShot(move);
            select = 3;
            stageSelectButton.Select();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && check)
        {
            GetComponent<AudioSource>().PlayOneShot(decision);
            obj3.SetActive(true);
            obj2.SetActive(false);
            check = false;
            yes = true;
            select = 0;
            backButton.Select();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !check && !e.activeSelf && pause)
        {
            GetComponent<AudioSource>().PlayOneShot(decision);
            obj3.SetActive(true);
            obj.SetActive(false);
            obj2.SetActive(false);
            pause = false;
            check = false;
            yes = true;
            select = 0;
            a[0].UnPause();
            a[1].UnPause();
            m.GetComponent<Move>().enabled = true;
            Time.timeScale = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !check && e.activeSelf)
        {
            GetComponent<AudioSource>().PlayOneShot(decision);
            obj3.SetActive(true);
            e.SetActive(false);
            backButton.Select();
            select = 0;
        }

        if (e.activeSelf && pause)
        {
            closeExplanationButton.Select();
        }

    }

    public void Button1()
    {
        obj.SetActive(false);
        pause = false;
        a[0].UnPause();
        a[1].UnPause();
        m.GetComponent<Move>().enabled = true;
        Time.timeScale = 1;
    }
    public void Button2()
    {
        obj3.SetActive(false);
        e.SetActive(true);
        select = 1;
        closeExplanationButton.Select();
    }

    public void Button3()
    {
        obj3.SetActive(false);
        obj2.SetActive(true);
        check = true;
        yesButton.Select();
        select = 2;
        if (SceneManager.GetActiveScene().name == "Stage4")
        {
            t.text = "このステージを諦めますか？\n(ステージ選択画面に戻ります)";
        }
        else
        {
            t.text = "このステージを諦めますか？\n(次のステージを解放して\nステージ選択画面に戻ります)";
        }

    }


    public void Button4()
    {
        obj3.SetActive(false);
        obj2.SetActive(true);
        check = true;
        yesButton.Select();
        select = 3;
        t.text = "ステージ選択へ戻りますか？";
    }

    public void Button5()
    {
        obj3.SetActive(true);
        e.SetActive(false);
        backButton.Select();
        select = 0;
    }

    public void YesButton()
    {
        if (select == 1)
        {
            r.a();
        }
        else if (select == 2)
        {
            Time.timeScale = 1;

            if (SceneManager.GetActiveScene().name == "Stage1") Choice.ReleaseFlag[0] = true;
            if (SceneManager.GetActiveScene().name == "Stage2") Choice.ReleaseFlag[1] = true;
            if (SceneManager.GetActiveScene().name == "Stage3") Choice.ReleaseFlag[2] = true;
            if (SceneManager.GetActiveScene().name == "Stage4") Choice.ReleaseFlag[3] = true;
            if (SceneManager.GetActiveScene().name == "Stage5") Choice.ReleaseFlag[4] = true;

            if (SceneManager.GetActiveScene().name == "Stage1" && PlayerPrefs.GetInt("RELEASE FLAG", 0) == 0)
            {
                Choice.flag=1;
                PlayerPrefs.SetInt("RELEASE FLAG", Choice.flag);
            }
            if (SceneManager.GetActiveScene().name == "Stage2" && PlayerPrefs.GetInt("RELEASE FLAG", 0) == 1)
            {
                Choice.flag=2;
                PlayerPrefs.SetInt("RELEASE FLAG", Choice.flag);
            }
            if (SceneManager.GetActiveScene().name == "Stage3" && PlayerPrefs.GetInt("RELEASE FLAG", 0) == 2)
            {
                Choice.flag=3;
                PlayerPrefs.SetInt("RELEASE FLAG", Choice.flag);
            }
            if (SceneManager.GetActiveScene().name == "Stage4" && PlayerPrefs.GetInt("RELEASE FLAG", 0) == 3)
            {
                Choice.flag++;
                PlayerPrefs.SetInt("RELEASE FLAG", Choice.flag);
            }
            if (SceneManager.GetActiveScene().name == "Stage5" && PlayerPrefs.GetInt("RELEASE FLAG", 0) == 4)
            {
                Choice.flag++;
                PlayerPrefs.SetInt("RELEASE FLAG", Choice.flag);
            }
            cho();
            
        }
        else if (select == 3)
        {
            cho();
            Time.timeScale = 1;
        }

    }

    void cho()
    {
        FadeManager.Instance.LoadScene("Choice", 0.5f);
    }

    public void NoButton()
    {
        obj3.SetActive(true);
        obj2.SetActive(false);
        check = false;
        select = 0;
        yes = true;
        backButton.Select();
    }

}