using UnityEngine;
using System.Collections;

public class MoveLiftX : MonoBehaviour
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
			this.gameObject.transform.position += new Vector3(Time.deltaTime * speed,0, 0);
		}
		else
		{
			this.gameObject.transform.position -= new Vector3(Time.deltaTime * speed,0, 0);
		}


		if (transform.position.x >= pos.x + range)
		{
			c = true;
		}
		else if (transform.position.x <= pos.x)
			c = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "attracted")
		{
			other.gameObject.transform.SetParent(this.transform);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "attracted")
		{
			other.gameObject.transform.SetParent(null);
		}
	}



}
