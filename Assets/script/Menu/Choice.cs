using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Choice : MonoBehaviour
{
    [SerializeField]
    public Button First, First2, Second, Third;

    [SerializeField]
    GameObject world, stage,ex;

    [SerializeField]
    AudioClip o;

    public static int flag = 0, flag2 = 0;

    public static bool[] ReleaseFlag = new bool[5];//[解放フラグ]
    public static bool[] ClearFlag = new bool[5];//[クリアフラグ]

    private string key = "RELEASE FLAG"; //ハイスコアの保存先キー
    private string key2 = "CLEAR FLAG"; //ハイスコアの保存先キー

    void Start()
    {
        First.Select();
       // First2.Select();



        //１面
        if (ClearFlag[0] == true || ReleaseFlag[0] == true || releaseget() >= 1 || clearget() >= 1) Second.interactable = true;
        if (ClearFlag[1] == true || ReleaseFlag[1] == true || releaseget() >= 2 || clearget() >= 2) Third.interactable = true;
        if (ClearFlag[2] == true || ReleaseFlag[2] == true || releaseget() >= 3 || clearget() >= 3) Second.interactable = true;

        //２面

        if (ClearFlag[3] == true || ReleaseFlag[3] == true || releaseget() >= 4 || clearget() >= 4) Third.interactable = true;

        if ((ClearFlag[0] == true && ClearFlag[1] == true && ClearFlag[2] == true) || clearget() >= 3) ex.SetActive(true);

    }

    private void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            
             First.Select();

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponent<AudioSource>().PlayOneShot(o);
           Title();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.DownArrow))
        {
            GetComponent<AudioSource>().Play();
        }

    }

    public void Stage1()
    {
        //Invoke("a", 1);
        FadeManager.Instance.LoadScene("Stage1", 0.5f);
    }

    public void Stage2()
    {
        FadeManager.Instance.LoadScene("Stage2", 0.5f);
    }

    public void Stage3()
    {
        FadeManager.Instance.LoadScene("Stage3", 0.5f);
    }

    void c()
    {
        FadeManager.Instance.LoadScene("title", 0.5f);
    }

    public void World1()
    {
        world.SetActive(false);
        stage.SetActive(true);
        First.Select();
       // off = true;

    }

    public void World2()
    {

    }

    public void Back()
    {
        stage.SetActive(false);
        world.SetActive(true);
        First2.Select();
        //off = false;

    }

    public void Title()
    {
        Invoke("c",0.3f);
    }

    void a()
    {
        FadeManager.Instance.LoadScene("Stage1", 0.5f);
    }

    public int releaseget()
    {
        return PlayerPrefs.GetInt(key, 0);
    }

    public int clearget()
    {
        return PlayerPrefs.GetInt(key2, 0);
    }

}