using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private Text score;
	private int counter;
	// Use this for initialization
	void Start () {
		score = GetComponentInChildren<Text> ();
		counter = 0;
		StaticScore.Score = counter;
		score.text = "Score : " + counter;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void incScore()
	{
		counter += 1;
		StaticScore.Score = counter;
		score.text = "Score : " + counter;
	}
}
