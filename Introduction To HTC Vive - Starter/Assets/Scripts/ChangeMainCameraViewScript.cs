using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMainCameraViewScript : MonoBehaviour {

    private float delta = 0.05f;
    Vector3 screenPoint, rotationOffset;
    private float smooth = 50.0F;
    private float tiltAngle = 30.0F;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float speedH = 2.0f;
    private float speedV = 2.0f;
    private Vector3 dragOrigin;
    private Vector3 dragAfter; // = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //bool supportsMultiTouch = Input.multiTouchEnabled;
        //print("MultiTouchSupport : " + supportsMultiTouch);

        if (Input.GetMouseButtonDown(1))
        {
            dragOrigin = Input.mousePosition;
            dragAfter = Camera.main.transform.eulerAngles;
        }

        if (Input.GetMouseButton(1))
        {


            if (Input.GetKey(KeyCode.W))
            {
                moveForward();
            }
            if (Input.GetKey(KeyCode.A))
            {
                moveLeft();
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveBackward();
            }
            if (Input.GetKey(KeyCode.D))
            {
               moveRight();
            }
            if (Input.GetKey(KeyCode.Space))
            {
                moveUp();
            }
            if (Input.GetKey(KeyCode.X))
            {
                moveDown();
            }

            
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3( pos.y * (-smooth), pos.x * smooth, 0);
            Camera.main.transform.eulerAngles = move + dragAfter;
        }
    }

    private void moveForward()
    {
        Vector3 pos = this.transform.position;
        pos += this.transform.forward * delta;
        this.transform.position = pos;
    }
    private void moveBackward()
    {
        Vector3 pos = this.transform.position;
        pos -= delta * this.transform.forward;
        this.transform.position = pos;
    }
    private void moveLeft()
    {
        Vector3 pos = this.transform.position;
        pos.x -= delta;
        this.transform.position = pos;
    }
    private void moveRight()
    {
        Vector3 pos = this.transform.position;
        pos.x += delta;
        this.transform.position = pos;
    }
    private void moveUp()
    {
        Vector3 pos = this.transform.position;
        pos.y += delta;
        this.transform.position = pos;
    }
    private void moveDown()
    {
        Vector3 pos = this.transform.position;
        pos.y -= delta;
        this.transform.position = pos;
    }


    private void rotateLeft()
    {
        yaw -= -speedH * Input.GetAxis("Horizontal");
        //pitch += -speedV * Input.GetAxis("Vertical");
        Camera.main.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
    private void rotateRight()
    {
        yaw += speedH * Input.GetAxis("Horizontal");
        //pitch -= speedV * Input.GetAxis("Vertical");
        Camera.main.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
