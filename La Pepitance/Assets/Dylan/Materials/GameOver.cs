using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
	
	// Use this for initialization
	void Start ()
	{
		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
