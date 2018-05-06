using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLight : MonoBehaviour {

	public Light lightFlashing;
	public float minWaitTime;
	public float maxWaitTime;

	// Use this for initialization
	void Start () {
		StartCoroutine (Flashing ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Flashing(){
		while (true) {
			yield return new WaitForSeconds (Random.Range (minWaitTime, maxWaitTime));
			lightFlashing.enabled = !lightFlashing.enabled;
		}
	}
}
