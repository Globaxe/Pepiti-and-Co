using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputfieldscript : MonoBehaviour {

	public InputField inputfield;
	public GameObject bowser;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void text()
	{
		if (inputfield.text == "bowser".ToString()) {
			Debug.Log ("True");
			GameObject.Destroy(bowser);
			inputfield.text = "";
		} else {
			Debug.Log ("False");
		}
	}

}
