using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

	public Text myText;
	private int counter;
	private bool spawning;
	private Color EndColor;
	private string[] workingText;
	private string line;


	// Use this for initialization
	void Start ()
	{
		AudioSource audio = GetComponent<AudioSource> ();
		audio.Play ();

		workingText = new string[myText.text.Length];
		for (int i = 0; i < myText.text.Length; i++) {
			workingText [i] = myText.text.ToCharArray () [i].ToString ();
		}
		counter = 0;
		spawning = false;
		EndColor = Color.green;
		EndColor.a = 1;
	}
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (workingText [counter].ToString ())) {
			workingText [counter] = "<color=green>" + workingText [counter].ToString () + "</color>";
			myText.text = "";
			foreach (string str in workingText) {
				myText.text += str;
			}
			counter++;
			if (counter == workingText.Length) {
				RestartGame (0);
			}
		}
	}

	public void RestartGame (int id)
	{
		Debug.Log ("Yep");
		SceneManager.LoadScene (id);
	}
}
