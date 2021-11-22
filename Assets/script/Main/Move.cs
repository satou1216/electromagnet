using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    GameObject Player;
    public int horizon;
    public int vertical;
    bool stay;
    public bool change;
    public bool rock;
    public Text t, t2;
    bool goal;
    bool LR;

    Result r;

    Animator ani;

    Vector3 x;

   AudioSource mjump, eleki, off,clear;

    // Use this for initialization

    [SerializeField]
    GameObject effect;
    void Start()
    {
        Player = gameObject;
        t = GameObject.Find("Clear").GetComponent<Text>();
        t2 = GameObject.Find("score").GetComponent<Text>();
        r = GameObject.Find("RetryObj").GetComponent<Result>();

        ani = GetComponent<Animator>();
        AudioSource[] audios = GetComponents<AudioSource>();
        mjump = audios[0];
        eleki = audios[1];
        off = audios[2];
        clear = audios[3];

    }

    // Update is called once per frame
    void Update()
    {
        if (rock == false)
        {
            ani.SetFloat("Speed", Player.GetComponent<Rigidbody>().velocity.magnitude);

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                //horizon = 10;
                if (LR == true)
                {
                    transform.Rotate(new Vector3(0, 180, 0));
                    transform.GetChild(0).transform.Rotate(new Vector3(0, 180, 0));

                    transform.GetChild(1).transform.Rotate(new Vector3(0, 180, 0));
                    LR = false;
                }
                Player.GetComponent<Rigidbody>().velocity = new Vector3(horizon, Player.GetComponent<Rigidbody>().velocity.y, 0);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                //horizon = 10;
                if (LR == false)
                {
                    transform.Rotate(new Vector3(0, 180, 0));
                    transform.GetChild(0).transform.Rotate(new Vector3(0, 180, 0));
                    transform.GetChild(1).transform.Rotate(new Vector3(0, 180, 0));
                    LR = true;
                }
                Player.GetComponent<Rigidbody>().velocity = new Vector3(-horizon, Player.GetComponent<Rigidbody>().velocity.y, 0);
            }

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && stay == true)
            {
                Player.GetComponent<Rigidbody>().velocity = new Vector3(Player.GetComponent<Rigidbody>().velocity.x, vertical, 0);

                stay = false;
                mjump.PlayOneShot(mjump.clip);

            }//è¨ÉWÉÉÉì
            else if ((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W)))
            {
                if (Player.GetComponent<Rigidbody>().velocity.y > 0)
                {
                    Invoke("jump", 0.1f);

                    //Player.GetComponent<Rigidbody>().velocity = new Vector3(Player.GetComponent<Rigidbody>().velocity.x, 0, 0);
                }
                stay = false;
            }


            if (Input.GetKeyDown(KeyCode.Y)|| Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.C))
            {
                if (change == true)
                {
                    // change = !change;
                    //GetComponent<Renderer>().material.color = Color.black;
                    effect.SetActive(true);
                    eleki.PlayOneShot(eleki.clip);
                }

                if (change == false)
                {
                    //change = !change;
                    effect.SetActive(false);
                    off.PlayOneShot(off.clip);
                }
                change = !change;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && rock == true)
        {
            SceneManager.LoadScene("Choice");
        }


    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "goal" && goal == false)
        {
            Player.GetComponent<Rigidbody>().velocity = new Vector3(0, -1, 0);

            r.GetComponents<AudioSource>()[0].Stop();
            r.GetComponents<AudioSource>()[1].Stop();
            clear.PlayOneShot(clear.clip);

            t.enabled = true;
            t2.enabled = true;
            // Invoke("cho", 5);
            if (SceneManager.GetActiveScene().name == "Stage1")
            {
                // Choice.ClearFlag[0] = true;
                if (PlayerPrefs.GetInt("CLEAR FLAG", 0) == 0)
                {
                    Choice.flag2=1;
                    PlayerPrefs.SetInt("CLEAR FLAG", Choice.flag2);
                }
            }
            if (SceneManager.GetActiveScene().name == "Stage2")
            {
                Choice.ClearFlag[1] = true;
                if (PlayerPrefs.GetInt("CLEAR FLAG", 0) == 1)
                {
                    Choice.flag2=2;
                    PlayerPrefs.SetInt("CLEAR FLAG", Choice.flag2);
                }
            }

            if (SceneManager.GetActiveScene().name == "Stage3")
            {
                Choice.ClearFlag[2] = true;
                if (PlayerPrefs.GetInt("CLEAR FLAG", 0) == 2)
                {
                    Choice.flag2=3;
                    PlayerPrefs.SetInt("CLEAR FLAG", Choice.flag2);
                }
            }


            rock = true;
            r.input();
            goal = true;
            ani.speed = 0;
            Point.pointflag = false;

        }




    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Attractor>() == null && other.gameObject.tag != "magnet")
        {
            stay = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Attractor>() == null && other.gameObject.tag != "magnet")
        {
            stay = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Attractor>() != null || collision.gameObject.tag == "magnet")
        {
            stay = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "magnet" && change)
        {
            stay = true;
        }

        if (collision.gameObject.GetComponent<Attractor>() != null)
        {
            stay = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Attractor>() != null || collision.gameObject.tag == "magnet")
        {
            stay = false;
        }
    }





    void cho()
    {
        SceneManager.LoadScene("Choice");
    }

    void jump()
    {
        Player.GetComponent<Rigidbody>().velocity = new Vector3(Player.GetComponent<Rigidbody>().velocity.x, 0, 0);
       
    }

    /* private void OnTriggerEnter(Collider other)
     {
         if (other.gameObject.tag == "magnet" && change == true)
         {
             set = true;
         }
         else
         {
             set = false;
         }
     }
     */
}

