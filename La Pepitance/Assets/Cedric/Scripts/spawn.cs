using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {

	public GameObject plateforme;
	public string textToWrite;

	private TextMesh myText;
	private int counter;
	private bool spawning;
	private Color EndColor;
	private string[] workingText;


	// Use this for initialization
	void Start () {
		myText = GetComponentInChildren<TextMesh> ();
		myText.text = textToWrite;
		workingText = new string[myText.text.Length];
		for(int i = 0; i<myText.text.Length;i++){
			workingText[i]=myText.text.ToCharArray()[i].ToString();
		}
		counter = 0;
		spawning = false;
		EndColor = plateforme.GetComponent<Renderer> ().material.color;
		EndColor.a = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (!spawning) {
			if (Input.GetKey (workingText[counter].ToString ())) {
				workingText [counter] = "<color=green>" + workingText [counter].ToString () + "</color>";
				myText.text = "";
				foreach (string str in workingText) {
					myText.text += str;
				}
				Debug.Log (myText.text);
				counter++;
				if (counter == workingText.Length) {
					spawning = true;
				}
			}

		} else {
			plateforme.GetComponent<Renderer> ().material.color = Color.Lerp (plateforme.GetComponent<Renderer> ().material.color, EndColor, Time.deltaTime);	
		}
	}
}
