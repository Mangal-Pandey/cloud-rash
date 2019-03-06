//WORKING COPY. Every latest version updated to BikeController.cs


//Trying to add inertia of motion


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentedBikeController : MonoBehaviour {


	public int animationTurnParam = 1;
	public int turnCurrentStat;
	Animator animator;


	//values for turnedCurrentStat
	const int ISSTRAIGHT = 1;
	const int TURNEDRIGHT = 2;
	const int TURNEDLEFT = 3;

	void Start () {
		animator = GetComponent<Animator> ();
		turnCurrentStat = ISSTRAIGHT;
	}

	void Update () {

		bool turningRight = Input.GetKey (KeyCode.RightArrow);
		bool turningLeft = Input.GetKey (KeyCode.LeftArrow);

		if (turningRight) {

			if (turnCurrentStat == ISSTRAIGHT)
				animationTurnParam = 2;
			else if (turnCurrentStat == TURNEDLEFT)
				animationTurnParam = 2;


			turnCurrentStat = TURNEDRIGHT;
		}

		if (turningLeft) {

			if (turnCurrentStat == ISSTRAIGHT)
				animationTurnParam = 5;
			else if (turnCurrentStat == TURNEDRIGHT)
				animationTurnParam = 5; 

			turnCurrentStat = TURNEDLEFT;
		}

		if ((!turningLeft && !turningRight) /*|| !moving*/) {

			if (turnCurrentStat == TURNEDRIGHT)
				animationTurnParam = 3;
			else if (turnCurrentStat == TURNEDLEFT)
				animationTurnParam = 1; 

			turnCurrentStat = ISSTRAIGHT;
		}

		animator.SetInteger("bikeAnimParam", animationTurnParam);
	}


}