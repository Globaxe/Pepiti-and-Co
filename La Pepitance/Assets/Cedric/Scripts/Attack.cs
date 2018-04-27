using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{


	private TextMesh myText;
	private int counter;
	private bool dying;
	private Color EndColor;
	private string[] workingText;
	private bool hasFocus;
	private Autoscroller scroll;
	private string line;
	public GameObject Player;
	private Vector3 PlayerPos;

	private float Speed = 1.0f;


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

		hasFocus = true;
		myText = GetComponentInChildren<TextMesh> ();
		myText.text = line;
		workingText = new string[myText.text.Length];
		for (int i = 0; i < myText.text.Length; i++) {
			workingText [i] = myText.text.ToCharArray () [i].ToString ();
		}
		counter = 0;
		dying = false;
	}

	// Update is called once per frame
	void Update ()
	{     
		PlayerPos = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
		transform.position = Vector3.MoveTowards(transform.position, PlayerPos, Speed * Time.deltaTime);
		
		if (!dying) {
			if (hasFocus) {
				if (Input.GetKey (workingText [counter].ToString ())) {
					workingText [counter] = "<color=green>" + workingText [counter].ToString () + "</color>";
					myText.text = "";
					foreach (string str in workingText) {
						myText.text += str;
					}
					counter++;
					if (counter == workingText.Length) {
						dying = true;
					}
				}
			}

		} else {
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.Equals (Player)) {
			//Player a mal
			Destroy(this.gameObject);
		};

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
