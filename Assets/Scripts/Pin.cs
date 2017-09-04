using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshold = 3f;


    private Rigidbody rigibody;

    public bool IsStanding()
    {
        //rotatiuon always 360 grados
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

       
        float tiltInX = Mathf.Abs(rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        if (tiltInX < standingThreshold && tiltInZ < standingThreshold)
        {
            return true;
        }

        return false;
    }

	// Use this for initialization
	void Start () {
        rigibody = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RaiseIfStanding(float distanceToRise)
    {
        if (IsStanding())
        {

            rigibody.useGravity = false;
            transform.Translate(new Vector3(0, distanceToRise, 0));
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

    public void Lower(float distanceToRise)
    {
        transform.Translate(new Vector3(0, -distanceToRise, 0));
        rigibody.useGravity = true;

    }
}
