using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour {

	int hatch = 10;
	public GameObject chick;
	public Transform curpos;
	private AudioSource eggAudio;
	public AudioClip tweetEgg;

	Animator eggo;

	// Use this for initialization
	void Start () 
	{
		eggAudio = GetComponent<AudioSource> ();
		eggAudio.clip = tweetEgg;
		curpos = gameObject.transform;
		eggo = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if(hatch == 0)
		{
			Instantiate (chick, curpos);
			//particle effect
			Destroy (gameObject);
		}
	}

	public void EggClick()
	{
		hatch--;
		eggo.SetTrigger("Clicked");
		eggAudio.Play();
		Debug.Log ("You clicked an egg");
	}


}
