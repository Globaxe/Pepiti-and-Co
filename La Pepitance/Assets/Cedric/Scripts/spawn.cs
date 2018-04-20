using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{

	public GameObject plateforme;

	private TextMesh myText;
	private int counter;
	private bool spawning;
	private Color EndColor;
	private string[] workingText;
	private bool hasFocus;
	private Autoscroller scroll;
	private string line;



	// Use this for initialization

	void Start ()
	{


		//Maybe change the path
		string fileName = "Assets/Luc/Resources/demi_liste_francais_utf8.txt";

		List<string> lines = new List<string> ();
		StreamReader reader = File.OpenText (fileName);
		while (!reader.EndOfStream) {
			lines.Add (reader.ReadLine ());
		}
		reader.Close ();

		// Seed a random number in the range 0 to lines length
		int randomNumber = Random.Range (0, lines.Count);

		// Read the random line
		line = lines [randomNumber];

		hasFocus = false;
		myText = GetComponentInChildren<TextMesh> ();
		scroll = GameObject.FindObjectOfType<Autoscroller> ();
		myText.text = line;
		workingText = new string[myText.text.Length];
		for (int i = 0; i < myText.text.Length; i++) {
			workingText [i] = myText.text.ToCharArray () [i].ToString ();
		}
		counter = 0;
		spawning = false;
		EndColor = plateforme.GetComponent<Renderer> ().material.color;
		EndColor.a = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!spawning) {
			if (hasFocus) {
				if (Input.GetKey (workingText [counter].ToString ())) {
					workingText [counter] = "<color=green>" + workingText [counter].ToString () + "</color>";
					myText.text = "";
					foreach (string str in workingText) {
						myText.text += str;
					}
					counter++;
					if (counter == workingText.Length) {
						spawning = true;
						scroll.GetComponent<Autoscroller> ().NextPlateform ();
					}
				}
			}

		} else {
			plateforme.GetComponent<Renderer> ().material.color = Color.Lerp (plateforme.GetComponent<Renderer> ().material.color, EndColor, Time.deltaTime);	
		}
	}

	public void giveFocus ()
	{
		hasFocus = true;
	}

	public void letFocus ()
	{
		hasFocus = false;
	}
}
