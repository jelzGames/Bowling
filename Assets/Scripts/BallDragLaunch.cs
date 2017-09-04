using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

    private Ball ball;
    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;


    // Use this for initialization
    void Start () {
        ball = GetComponent<Ball>();
	}

    public void DragStart()
    {
        //capture time and position of drag start
        if (!ball.inPlay)
        {
            dragStart = Input.mousePosition;
            startTime = Time.time;
        }

    }

    public void MoveToStart(float amount)
    {
        if (!ball.inPlay)
        {
            float xPos = Mathf.Clamp(ball.transform.position.x + amount, -50f, 50f);
            float yPos = ball.transform.position.y;
            float zPos = ball.transform.position.z;
            ball.transform.position = new Vector3(xPos, yPos, zPos);
        }
    }

    public void DragEnd()
    {
        if (!ball.inPlay)
        {
            //launch ball

            dragEnd = Input.mousePosition;
            endTime = Time.time;

            //time in seconds
            float dragDuration = endTime - startTime;
            float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
            // y is going to be z en 2D panel (SPEED)
            float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

            Vector3 velocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
            ball.Launch(velocity);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
