using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Title : MonoBehaviour
{
    [SerializeField]
    Button b1;
    [SerializeField]
    Button b2;
    [SerializeField]
    Button b3;
    [SerializeField]
    Button b4;
    [SerializeField]
    Button b5;
    [SerializeField]
    Button b6;

    [SerializeField]
    GameObject buttons;
    [SerializeField]
    GameObject expalanationObj;
    [SerializeField]
    GameObject expalanationText;
    [SerializeField]
    GameObject creditText;
    [SerializeField]
    GameObject endText;
    [SerializeField]
    Image creditImage;
    [SerializeField]
    Image titleImage;

    private int state;
    private int select;
    private bool skip;
    private bool select2;
    private bool stage4;

    public AudioClip move,ex;


    // Start is called before the first frame update
    void Start()
    {
        b1.Select();
        state = 0;
        select = 0;
        skip = false;
        select2 = false;
        stage4 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 2 && endText.transform.position.y < Screen.height / 2.0f && !skip)
        {
            creditText.transform.position += new Vector3(0f, 1.0f, 0f);
        }
        else if (state == 2 && endText.transform.position.y < Screen.height / 2.0f && skip && !select2)
        {
            creditText.transform.position += new Vector3(0f, 8.0f, 0f);
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return) && !select2 && state == 2)
        {
            skip = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Return) && !select2 && state == 2)
        {
            skip = false;
        }


        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            if (state == 0)
            {
                b1.Select();
                select = 0;
            }
            else if (state == 1)
            {
                b5.Select();
            }
            else if (state == 2)
            {
                b6.Select();
                select2 = false;
            }
        }

        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && select < 3 && state == 0)
        {
            GetComponent<AudioSource>().PlayOneShot(move);
            select += 1;
        }
        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && select > 0 && state == 0)
        {
            GetComponent<AudioSource>().PlayOneShot(move);
            select -= 1;
        }
        else if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && select == 3 && state == 0)
        {
            GetComponent<AudioSource>().PlayOneShot(move);
            select = 0;
            b1.Select();
        }
        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && select == 0 && state == 0)
        {
            GetComponent<AudioSource>().PlayOneShot(move);
            select = 3;
            b4.Select();
        }

        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && !select2 && state == 2)
        {
            GetComponent<AudioSource>().PlayOneShot(move);
            select2 = true;
        }
        else if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && select2 && state == 2)
        {
            GetComponent<AudioSource>().PlayOneShot(move);
            select2 = false;
        }
        else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && select2 && state == 2)
        {
            GetComponent<AudioSource>().PlayOneShot(move);
            select2 = false;
            b6.Select();
        }
        else if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && !select2 && state == 2)
        {
            GetComponent<AudioSource>().PlayOneShot(move);
            select2 = true;
            b5.Select();
        }


        if (Input.GetKey(KeyCode.K) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Y) && !stage4)
        {
            GetComponent<AudioSource>().PlayOneShot(ex);
            s4();
            stage4 = true;
        };

        


    }

    void s4()
    {
        FadeManager.Instance.LoadScene("Stage4", 0.5f);
    }


    public void StartGame()
    {
        a();
    }

    public void a()
    {
        FadeManager.Instance.LoadScene("Choice", 0.5f);
    }

    public void Explanation()
    {
        buttons.SetActive(false);
        expalanationObj.SetActive(true);
        expalanationText.SetActive(true);
        titleImage.gameObject.SetActive(false);
        b5.gameObject.SetActive(true);
        state = 1;
        b5.Select();
        Time.timeScale = 0;
    }

    public void Credit()
    {
        buttons.SetActive(false);
        creditText.transform.position = new Vector3(buttons.transform.position.x, buttons.transform.position.y - 700, buttons.transform.position.z);
        creditText.SetActive(true);
        titleImage.gameObject.SetActive(false);
        creditImage.gameObject.SetActive(true);
        state = 2;
        b5.gameObject.SetActive(true);
        b6.gameObject.SetActive(true);
        b6.Select();


    }

    public void Back()
    {
        expalanationObj.SetActive(false);
        expalanationText.SetActive(false);
        creditText.SetActive(false);
        creditImage.gameObject.SetActive(false);
        titleImage.gameObject.SetActive(true);
        buttons.SetActive(true);
        b5.gameObject.SetActive(false);
        b6.gameObject.SetActive(false);
        b1.Select();
        state = 0;
        select = 0;
        select2 = false;
        skip = false;
        Time.timeScale = 1;
    }

    public void Skip()
    {
        skip = true;
    }

    public void SkipOff()
    {
        skip = false;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;   // UnityEditorÇÃé¿çsÇí‚é~Ç∑ÇÈèàóù
#else
        Application.Quit();                                // ÉQÅ[ÉÄÇèIóπÇ∑ÇÈèàóù
#endif
    }
}