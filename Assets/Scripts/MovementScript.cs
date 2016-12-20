using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	public float speed;
	public float bulletSpeed;
	public float padding{ get; set;}

	public GameObject bulletPrefab;

	private int timer = 0;

	// Use this for initialization
	void Start () {
		speed = 19f;
	}
	
	// Update is called once per frame
	void Update () {

		Camera.main.transform.position = new Vector3 (transform.position.x, transform.position.y, -10f);

		Rigidbody2D body = transform.GetComponent<Rigidbody2D> ();

		if (Input.GetKeyDown (KeyCode.S))
			body.velocity = new Vector2(body.velocity.x,-speed);
		if (Input.GetKeyUp (KeyCode.S))
			body.velocity = new Vector2(body.velocity.x,0);
		if (Input.GetKeyDown (KeyCode.W))
			body.velocity = new Vector2(body.velocity.x,speed);
		if (Input.GetKeyUp (KeyCode.W))
			body.velocity = new Vector2(body.velocity.x,0);
		if (Input.GetKeyDown (KeyCode.A))
			body.velocity = new Vector2 (-speed, body.velocity.y);
		if (Input.GetKeyUp (KeyCode.A))
			body.velocity = new Vector2 (0, body.velocity.y);
		if (Input.GetKeyDown (KeyCode.D))
			body.velocity = new Vector2 (speed, body.velocity.y);
		if (Input.GetKeyUp (KeyCode.D))
			body.velocity = new Vector2 (0, body.velocity.y);


		timer++;
		if (Input.GetKey (KeyCode.Mouse0) && timer % 5 == 0) {
			shoot ();
			timer = 0;
		}

		rotateEveryFrame ();
	}

	void rotateEveryFrame()
	{
		Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.rotation = Quaternion.LookRotation (Vector3.forward, mouse - transform.position);
	}

	public void shoot()
	{
		Vector2 myPos = transform.position;
		Vector3 spawnPos = new Vector3 (myPos.x, myPos.y, 1f);
		Vector2 cursorPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 direction = cursorPos - myPos;
		direction.Normalize ();
		GameObject projectile = Instantiate (bulletPrefab, spawnPos, Quaternion.identity) as GameObject;
		projectile.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;
	}
}
