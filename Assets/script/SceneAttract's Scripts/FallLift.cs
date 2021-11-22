using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallLift : MonoBehaviour
{
	private Vector3 pos;
	[SerializeField]
	int fallSpeed = 1;
	
	private bool fall = false;
	private float startFallTime = 0;
	[SerializeField]
	float startFall = 1;

	private bool respawn = false;
	private float respawnTime = 0;
	[SerializeField]
	float respawnInterval = 3;

	private float a = 1f;


	void Start()
	{

		pos = transform.position;
	}

	void FixedUpdate()
	{
		if (fall)
		{
			startFallTime += Time.deltaTime;
			a += 0.07f;
			if (startFallTime > startFall)
			{
				this.gameObject.transform.position += new Vector3(0f, -Time.deltaTime * fallSpeed * a, 0f);
			}
		}

        if (this.gameObject.transform.position.y <=-15)
        {
			respawnTime += Time.deltaTime;
			fall = false;
        }if(respawnTime > respawnInterval)
        {
			respawn = false;
			respawnTime = 0;
			this.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
		}

	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "attracted")
		{
			col.gameObject.transform.SetParent(this.transform);
			fall = true;
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
		respawn = true;
		a = 1f;
		startFallTime = 0;

	}

  

}
