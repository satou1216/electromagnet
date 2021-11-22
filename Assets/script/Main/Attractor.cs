using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Attractor : MonoBehaviour
{
    /* Vector3 vec;

     private void Start()
     {
         vec=new Vector3(1f,0,1f);
     }
     private void OnTriggerStay(Collider other)
     {
         if (other.gameObject.tag == "magnet")
         {
             float step = 1 * Time.deltaTime;
             transform.position = Vector3.MoveTowards(transform.position, other.transform.position, step);

         }
     }

     */

    public float forceFactor = 1f;
    Move m;
    //List<Rigidbody> objectBodies = new List<Rigidbody>();

    void Start()
    {
        m = GameObject.Find("Player").GetComponent<Move>();
    }

    private void OnTriggerEnter(Collider other)
    {/*
        if (other.gameObject.tag == "attracted")
        {
            if (m.change == false)
            {
                //other.gameObject.GetComponent<Rigidbody>().AddForce(GetForce(other.gameObject.transform.position));
                m.GetComponents<AudioSource>()[4].Play();

            }
        }*/
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "attracted")
        {
            if (m.change == false)
            {
                other.gameObject.GetComponent<Rigidbody>().AddForce(GetForce(other.gameObject.transform.position));
               // m.GetComponents<AudioSource>()[4].PlayOneShot(m.GetComponents<AudioSource>()[4].clip);

            if(!m.GetComponents<AudioSource>()[4].isPlaying) m.GetComponents<AudioSource>()[4].Play();

            }
            else m.GetComponents<AudioSource>()[4].Stop();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "attracted") m.GetComponents<AudioSource>()[4].Stop();
    }

    void FixedUpdate()
    {

    }

    Vector3 GetForce(Vector3 pos)
    {
        float dist = Vector3.Distance(transform.position, pos);
        Vector3 dir = (transform.position - pos).normalized;
        return dir / (dist * dist) * forceFactor;
    }
}