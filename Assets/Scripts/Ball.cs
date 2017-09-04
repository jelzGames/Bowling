using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector3 launchVelocity;
    public bool inPlay = false;

    private Rigidbody rigiBody;
    private AudioSource audioSource;
    
    private Vector3 ballStartPos;
   
	// Use this for initialization
	void Start () {
        rigiBody = GetComponent<Rigidbody>();
        rigiBody.useGravity = false;
        ballStartPos = transform.position;
   
        // only for testing
        //Launch(launchVelocity);


    }

    public void Launch(Vector3 velocity)
    {
        inPlay = true;
        rigiBody.useGravity = true;
        rigiBody.velocity = velocity;

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Reset()
    {
        inPlay = false;
        transform.position = ballStartPos;
        transform.rotation = Quaternion.identity;
        rigiBody.velocity = Vector3.zero;
        rigiBody.angularVelocity = Vector3.zero;
        rigiBody.useGravity = false;
    }
}
