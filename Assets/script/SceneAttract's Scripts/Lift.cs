using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
	private Vector3 pos;
	[SerializeField]
	int speed = 1;
	[SerializeField]
	int range = 5;
	bool c;
	bool no;

	void Start()
	{

		pos = transform.position;
		c = false;
		no = false;
	}

	void Update()
	{

		if (c && transform.position.x < pos.x + range)
		{
			this.gameObject.transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
		}


		if (no)
		{
			transform.position = pos;
			c = false;
			no = false;

		}



	}
		



	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "attracted")
		{
			col.gameObject.transform.SetParent(this.transform);
			c = true;
		}
	}

	void OnCollisionExit(Collision col)
	{
		if (col.gameObject.tag == "attracted")
		{
			col.gameObject.transform.SetParent(null);
		}


	}

    private void OnBecameInvisible()
    {
		if(transform.position.x >= pos.x + range)
			no = true;
    }

}
