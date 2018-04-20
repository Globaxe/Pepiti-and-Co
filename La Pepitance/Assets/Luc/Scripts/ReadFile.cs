using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;

public class ReadFile : MonoBehaviour {

	public InputField inputfield;
	public Text wordToWrite;
	public GameObject bowser;

	private string line;

	// Use this for initialization
	void Start () {
		//Maybe change the path
		string fileName = "Assets/Luc/Resources/demi_liste_francais_utf8.txt";

		List<string> lines = new List<string>();
		StreamReader reader = File.OpenText (fileName);
		while (!reader.EndOfStream)
		{
			lines.Add(reader.ReadLine());
		}
		reader.Close();

		// Seed a random number in the range 0 to lines length
		int randomNumber = Random.Range(0,lines.Count);

		// Read the random line
		line = lines[randomNumber];
		wordToWrite.text = line.ToString();
		Debug.Log(line);
	}

	public void test()
	{
		if (inputfield.text == line.ToString()) {
			Debug.Log ("True");
			GameObject.Destroy(bowser);
			inputfield.text = "";
			wordToWrite.text = "";
		} else {
			Debug.Log ("False");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
