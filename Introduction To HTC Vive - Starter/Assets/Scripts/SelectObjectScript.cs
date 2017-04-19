using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObjectScript : MonoBehaviour {

    float delta = 0.05f;
//    private float yaw = Input.GetAxis("Horizontal");
//    private float pitch = Input.GetAxis("Vertical");
    private float speedH = 3.0f;
    private float speedV = 3.0f;
	private float yaw;
	private float pitch;

    private Rigidbody selected;
    private Color origColor;

	// Use this for initialization
	void Start () {
		yaw = Input.GetAxis("Horizontal");
		pitch = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
        // this code show nameobject with click   
        if (Input.GetMouseButtonDown(0))
        {
            //empty RaycastHit object which raycast puts the hit details into
            RaycastHit hit = new RaycastHit();
            //ray shooting out of the camera from where the mouse is
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                //print out the name if the raycast hits something
                Debug.Log(hit.collider.name);
                //freeclup= hit.collider.name;

                // Get the selected object
                //if (selected != hit.collider.gameObject.GetComponent<Rigidbody>() && selected)
                //{
                if (!hit.collider.gameObject.GetComponent<Rigidbody>()) return;
                    selected = hit.collider.gameObject.GetComponent<Rigidbody>();
                    Vector3 pos = selected.transform.position;
                    pos.y += delta;
                    selected.transform.position = pos;
                //Renderer r = hit.collider.gameObject.GetComponentInChildren<Renderer>();
                //Material m = r.material;
                //m.color = Color.green;
                //r.material = m;
                //}

            }
        }
    }
    void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //selected.AddForce(movement * 5.0f);

        if (Input.GetMouseButton(1)) return;

        if (Input.GetKey(KeyCode.W))
        {
            moveForward();
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                spinLeft();
            }
            else
                moveLeft();
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveBackward();
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                spinRight();
            }
            else
                moveRight();
        }
        if (Input.GetKey(KeyCode.Z))
        {
            moveUpward();
        }
        if (Input.GetKey(KeyCode.X))
        {
            moveDownward();
        }
        
    }

    private void moveForward()
    {
        Vector3 pos = selected.transform.position;
        pos.z += delta;
        selected.transform.position = pos;
    }
    private void moveBackward()
    {
        Vector3 pos = selected.transform.position;
        pos.z -= delta;
        selected.transform.position = pos;
    }
    private void moveLeft()
    {
        Vector3 pos = selected.transform.position;
        pos.x -= delta;
        selected.transform.position = pos;
    }
    private void moveRight()
    {
        Vector3 pos = selected.transform.position;
        pos.x += delta;
        selected.transform.position = pos;
    }
    private void moveUpward()
    {
        Vector3 pos = selected.transform.position;
        pos.y += delta;
        selected.transform.position = pos;
    }
    private void moveDownward()
    {
        Vector3 pos = selected.transform.position;
        pos.y -= delta;
        selected.transform.position = pos;
    }

    private void spinLeft()
    {
        yaw -= -speedH * Input.GetAxis("Horizontal");
        pitch += -speedV * Input.GetAxis("Vertical");
        selected.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
    private void spinRight()
    {
        yaw -= -speedH * Input.GetAxis("Horizontal");
        pitch += -speedV * Input.GetAxis("Vertical");
        selected.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
