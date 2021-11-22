using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Release : MonoBehaviour
{
    public float forceFactor = 1f;
    List<Rigidbody> objectBodies = new List<Rigidbody>();

    Move move;

    void Start()
    {
        move = gameObject.GetComponent<Move>();

        foreach (var obj in GameObject.FindGameObjectsWithTag("magnet"))
        {
            var rb = obj.GetComponent<Rigidbody>();
            if (rb == null)
            {
                continue;
            }
            objectBodies.Add(rb);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "magnet")
        {

           // if (move.change == false) GetComponents<AudioSource>()[4].Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "magnet")
        {

            if (move.change == false)
            {
                if (!GetComponents<AudioSource>()[4].isPlaying)GetComponents<AudioSource>()[4].Play();

                foreach (var rb in objectBodies)
                {
                    rb.mass = 0.1f;
                    rb.AddForce(GetForce(rb.transform.position));
                }
            }

            if (move.change == true)
            {
                GetComponents<AudioSource>()[4].Stop();
                foreach (var rb in objectBodies)
                {
                    rb.mass = 20f;
                    GetComponents<AudioSource>()[4].Stop();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "magnet") GetComponents<AudioSource>()[4].Stop();
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
/* private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "magnet")
        {
            if (move.change == true)
            {
                if (set == false)
                {
                    foreach (var rb in objectBodies)
                    {
                        rb.mass = 0.1f;
                        rb.AddForce(GetForce(rb.transform.position));
                    }
                }
                    if (Mathf.Abs(other.transform.position.x - transform.position.x) <= 1.5)
                    {
                        set = true;
                    }
                    else if (Mathf.Abs(other.transform.position.x - transform.position.x) > 1.5)
                    {
                        set = false;
                    }
                

            }
*/
