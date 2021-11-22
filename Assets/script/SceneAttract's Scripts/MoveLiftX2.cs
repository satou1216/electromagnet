using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLiftX2 : MonoBehaviour
{
	private Vector3 pos;
	[SerializeField]
	int speed = 1;
	[SerializeField]
	int range = 5;
	bool c;

	void Start()
	{

		pos = transform.position;
	}

	void Update()
	{

		if (!c)
		{
			this.gameObject.transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
		}
		else
		{
			this.gameObject.transform.position -= new Vector3(Time.deltaTime * speed, 0, 0);
		}


		if (transform.position.x >= pos.x + range)
		{
			c = true;
		}
		else if (transform.position.x <= pos.x)
			c = false;
	}


	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "attracted")
		{
			collision.gameObject.transform.SetParent(this.transform);
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.tag == "attracted")
		{
			collision.gameObject.transform.SetParent(null);
		}
	}

}
