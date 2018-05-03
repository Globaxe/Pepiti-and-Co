using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestOpponent : MonoBehaviour {

	public GameObject opponent;
	public GameObject player;
	public Time time;
	public float speed = 2f;
	public int maxOpp = 3;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", speed, speed);
	}
	
	// Update is called once per frame
	void Update () {
		for(int i =0;i<transform.childCount;i++)
		{
			transform.GetChild (i).GetComponent<Attack> ().letFocus ();
		}
		if (transform.childCount != 0) {
			transform.GetChild (0).GetComponent<Attack> ().giveFocus ();
		}
	}

	void Spawn(){
		if (transform.childCount<maxOpp) {
			GameObject opp = Instantiate (opponent, new Vector3 (transform.position.x ,transform.position.y,transform.position.z), transform.rotation);
			opp.GetComponent<Attack> ().player = player;
			opp.transform.rotation = Quaternion.Euler (Vector3.up * 180);
			opp.GetComponentInChildren<TextMesh>().transform.rotation = Quaternion.Euler (Vector3.up * 180);
			opp.transform.SetParent (transform);
		}
	}
}
