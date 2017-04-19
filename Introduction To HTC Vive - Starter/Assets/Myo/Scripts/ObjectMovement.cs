using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour {

	float delta = 0.05f;

	// Use this for initialization
	void Start () {

	}

	void moveLeft () {
		Vector3 position = this.transform.position;
		position.x = position.x - delta;
		this.transform.position = position;
	}

	void moveRight () {
		Vector3 position = this.transform.position;
		position.x = position.x + delta;
		this.transform.position = position;
	}

	void moveForward () {
		Vector3 position = this.transform.position;
		position.z = position.z + delta;
		this.transform.position = position;
	}

	void moveBackward () {
		Vector3 position = this.transform.position;
		position.z = position.z - delta;
		this.transform.position = position;
	}

	void moveUp () {
		Vector3 position = this.transform.position;
		position.y = position.y + delta;
		this.transform.position = position;
	}

	void moveDown () {
		Vector3 position = this.transform.position;
		position.y = position.y - delta;
		this.transform.position = position;
	}

	public float minX = -360.0f;
	public float maxX = 360.0f;

	public float minY = -45.0f;
	public float maxY = 45.0f;

	public float sensX = 100.0f;
	public float sensY = 100.0f;

	float rotationY = 0.0f;
	float rotationX = 0.0f;

	private float speed = 2.0f;
	// Update is called once per frame
	void Update () {
		//		double speed = 75.0;
		//		Vector3 v3 = Vector3(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), 0.0);
		//		transform.Rotate(v3 * speed * Time.deltaTime); 
		if (Input.GetKey(KeyCode.A) )
		{
			moveLeft();
			//			transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
		}
		if (Input.GetKey(KeyCode.D))
		{
			moveRight();
			//			transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
			//			rotationX += Input.GetAxis ("Mouse X") * sensX * Time.deltaTime;
			//			rotationY += Input.GetAxis ("Mouse Y") * sensY * Time.deltaTime;
			//			rotationY = Mathf.Clamp (rotationY, minY, maxY);
			//			transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
		}
		if (Input.GetKey(KeyCode.W))
		{
			moveForward();
			//			transform.Translate(new Vector3(0,speed * Time.deltaTime,0));

		}
		if (Input.GetKey(KeyCode.S))
		{
			moveBackward();
			//			transform.Translate(new Vector3(0,-speed * Time.deltaTime,0));
		}
		if (Input.GetKey (KeyCode.Space)) 
		{
			moveUp();
		}
		if (Input.GetKey (KeyCode.B)) 
		{
			moveDown();
		}
	}
}
