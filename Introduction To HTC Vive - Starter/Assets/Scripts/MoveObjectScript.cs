using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectScript : MonoBehaviour {

    float delta = 0.05f;
    private float yaw = Input.GetAxis("Horizontal");
    private float pitch = Input.GetAxis("Vertical");
    private float speedH = 3.0f;
    private float speedV = 3.0f;

    private bool isSelected = false;
    public bool getIsSelected() { return isSelected; }
    public void setIsSelected(bool select) { isSelected = select; }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)) return;

        //if (!isSelected) return;

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
    }

    private void moveForward()
    {
        Vector3 pos = this.transform.position;
        pos.z += delta;
        this.transform.position = pos;
    }
    private void moveBackward()
    {
        Vector3 pos = this.transform.position;
        pos.z -= delta;
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

    private void spinLeft()
    {
        yaw -= -speedH * Input.GetAxis("Horizontal");
        pitch += -speedV * Input.GetAxis("Vertical");
        this.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
    private void spinRight()
    {
        yaw -= -speedH * Input.GetAxis("Horizontal");
        pitch += -speedV * Input.GetAxis("Vertical");
        this.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
