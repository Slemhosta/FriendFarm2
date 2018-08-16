using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickSound : MonoBehaviour {

	private AudioSource tweeter;
	public AudioClip []tweet;
	public int currentTweet = 0;

	// Use this for initialization
	void Start () {

		tweeter = GetComponent<AudioSource> (); 
		tweeter.clip = tweet[0];
		StartCoroutine (tweetMachine ());
		
	}
	
	public IEnumerator tweetMachine(){
		
		float i = Random.Range (1f, 3f);
		yield return new WaitForSeconds (i);
		PickClip ();
		StartCoroutine (tweetMachine ());
	}

	public void PickClip(){

		currentTweet = Random.Range (0, tweet.Length);
		tweeter.clip = tweet[currentTweet];
		tweeter.Play();
	}
}
