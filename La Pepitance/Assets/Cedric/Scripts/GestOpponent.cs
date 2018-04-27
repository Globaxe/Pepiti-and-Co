using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestOpponent : MonoBehaviour {

	public GameObject opponent;
	public GameObject player;
	public Time time;
	public float speed = 5f;
	public int maxOpp = 3;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", speed, speed);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Spawn(){
		if (transform.childCount<maxOpp) {
			GameObject opp = Instantiate (opponent, new Vector3 (transform.position.x ,transform.position.y,transform.position.z), transform.rotation);
			opp.GetComponent<Attack> ().Player = player;
			opp.transform.SetParent (transform);
		}
	}
}
