﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour {

	//How far the player can see (how close something has to be so they can click it.)
	public float distanceToSee;
	//The layer everything they interact with must be on.
	public LayerMask interactionsLayer;
	//the hit so we can see what it hits in the console.
	RaycastHit hit;

	// Update is called once per frame
	void Update () {

		//Draw a ray so we can see it in the scene.
		Debug.DrawRay(transform.position, transform.forward * distanceToSee, Color.cyan);

		//Get an actual ray and print out everything we touch in the console.
		if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distanceToSee))
		{
			//Debug.Log("I touched " + hit.collider.gameObject.name);
		}

		//If the player clicks...
		if (Input.GetKeyUp(KeyCode.Mouse0))
		{
			//Get an array of everything that we hit.
			RaycastHit[] rayHits;
			//Get the ray from the position of the mouse.
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//Find all object that is close enough, hit by the ray, and on the interactionslayer.
			rayHits = Physics.RaycastAll(ray, 200.0f, interactionsLayer);

			//For every hit in the array...
			for (int i = 0; i < rayHits.Length; i++)
			{
				//Debug.Log("With the new Raycast, I touched " + rayHits[i].collider.gameObject.name);
				//Try to find the pickup script
				var pickupRef = rayHits[i].collider.gameObject.GetComponent<Egg>();
				//If we could find one...
				if (pickupRef != null) 
				{
					//call a function from the pickupscript
					pickupRef.EggClick ();
				}
			}
		}
	}
}
