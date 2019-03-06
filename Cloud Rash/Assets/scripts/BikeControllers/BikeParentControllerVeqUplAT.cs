
//Trying to add inertia of motion
/*
Motion parameters that'll vary with bike models:
1. accelerating power
2. braking power
3. turning radius (turning angle)
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeParentControllerVeqUplAT: MonoBehaviour {
    public float acceleratingPower, brakingPower;
    public float currentForwardSpeed, currentAccel;

    Rigidbody rb;

    bool accelerating, braking, turningRight, turningLeft;
    Vector3 currentVelocity, forward;
    float speedToTurnAngleMultiplier;

	void Start () {
		rb = GetComponent<Rigidbody> ();

        acceleratingPower = 50f;
        brakingPower = 40f;
        currentAccel = 0f;
        speedToTurnAngleMultiplier = 0.02f;

	}

	void Update () {
        accelerating = Input.GetKey(KeyCode.UpArrow);
        braking = Input.GetKey(KeyCode.DownArrow);
        turningRight = Input.GetKey(KeyCode.RightArrow);
        turningLeft = Input.GetKey(KeyCode.LeftArrow);

        forward = transform.forward.normalized;
        currentVelocity = rb.velocity;
        currentForwardSpeed = Vector3.Dot(currentVelocity, forward);


        if (accelerating)
        {
            //gradually increase forward velocity
            currentAccel = Mathf.Min(currentAccel + 0.5f, acceleratingPower);
        }
        else if (currentForwardSpeed > 0.8)
        {
            //gradually decrease forward velocity
            currentAccel = Mathf.Max(currentAccel - 0.1f, 0f);
        }

        if (braking)
        {
            //rapidly decrease forward velocity
            currentAccel = Mathf.Max(currentAccel - 0.5f, 0f);
        }

        rb.AddForce(forward * currentAccel, ForceMode.VelocityChange);

        if(currentForwardSpeed > 0.8) { 
            if (turningRight){
                //rotate bike to the right, gradually
                transform.RotateAround(transform.position, transform.up, currentForwardSpeed * speedToTurnAngleMultiplier);
            }

            if (turningLeft){
                //rotate bike to he left, gradually
                transform.RotateAround(transform.position, transform.up, -currentForwardSpeed * speedToTurnAngleMultiplier);
            }
        }

    }


}