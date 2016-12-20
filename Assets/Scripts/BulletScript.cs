using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float speed = 10f;
	Vector3 dir;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionEnter2D(Collision2D coll)
	{
		Destroy(this.gameObject);
	}

}
