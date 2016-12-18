using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float speed = 10f;
	Vector3 dir;


	// Use this for initialization
	void Start () {

		dir = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		//dir.Normalize();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += dir * speed * Time.deltaTime;
	}

	public void onCollisionEnter()
	{
		Destroy(this);
	}

}
