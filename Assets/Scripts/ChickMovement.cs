using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickMovement : MonoBehaviour {

	public Transform target;
	public Vector3 chickPosition;
	public float speed;
	public float rotationSpeed;
	public int maxRange;
	bool chickFollowNow = false;
	bool inRadius = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (inRadius|| chickFollowNow){
			Vector3 targetDirection = target.position - transform.position;
			var newDirection = Vector3.RotateTowards (transform.forward, targetDirection, rotationSpeed * Time.deltaTime,0.0f);
			transform.rotation = Quaternion.LookRotation (newDirection);
		}

		if ((Vector3.Distance (transform.position, target.position) < maxRange)) {
			if (!inRadius) {
				chickFollowNow = true;
			}
		}

		if ((Vector3.Distance (transform.position, target.position) > maxRange)) {
			chickFollowNow = false;
		}

		if (chickFollowNow == true) {

			chickPosition = transform.position;
			target = GameObject.FindWithTag ("Player").transform;
			transform.position = Vector3.MoveTowards (chickPosition, target.transform.position, speed * Time.deltaTime);
		}
	}

	public void OnTriggerEnter (Collider other){

		if (other.gameObject.CompareTag ("Player")) {
			inRadius = true;
			chickFollowNow = false;
		}
	}

	public void OnTriggerExit (Collider other){

		if (other.gameObject.CompareTag ("Player")) {
			inRadius = false;
			chickFollowNow = true;
		}
	}
}