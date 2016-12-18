using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	public float speed;
	public float padding{ get; set;}

	public GameObject bulletPrefab;

	float xMin;
	float xMax;

	float yMin;
	float yMax;

	// Use this for initialization
	void Start () {
		speed = 19f;
		padding = 0.51f;

		float distance = transform.position.z - Camera.main.transform.position.z;

		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1,0,distance));

		xMin = leftMost.x + padding;
		xMax = rightMost.x - padding;

		Vector3 upMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, distance));
		Vector3 downMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));

		yMin = downMost.y + padding;
		yMax = upMost.y - padding;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.S))
			transform.position += Vector3.down * speed * Time.deltaTime;
		if (Input.GetKey(KeyCode.W))
			transform.position += Vector3.up * speed * Time.deltaTime;
		if (Input.GetKey(KeyCode.A))
			transform.position += Vector3.left * speed * Time.deltaTime;
		if (Input.GetKey(KeyCode.D))
			transform.position += Vector3.right * speed * Time.deltaTime;

		//restrict x position
		float newX = Mathf.Clamp (transform.position.x, xMin, xMax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);

		//restrict y position
		float newY = Mathf.Clamp(transform.position.y, yMin, yMax);
		transform.position = new Vector3 (transform.position.x, newY, transform.position.z);

		if (Input.GetKeyDown (KeyCode.Mouse0))
			shoot ();

	}

	public void shoot()
	{
		Quaternion angle = Camera.main.ViewportToWorldPoint (Input.mousePosition);
		GameObject bullet = Instantiate (bulletPrefab, transform.position , Quaternion.identity) as GameObject;
		bullet.transform.parent = transform;
	}
}
