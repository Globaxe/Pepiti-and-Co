using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;
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
	public GameObject player = null;
	private Vector3 PlayerPos;
	private ScoreManager scoreManager;
	private bool hurtOnlyOnce;

	private float Speed = 2.5f;


	// Use this for initialization

	void Start ()
	{

		hurtOnlyOnce = true;
		//Maybe change the path
		string fileName = Application.dataPath+"/demi_liste_francais_utf8.txt";
		scoreManager = GameObject.FindObjectsOfType<ScoreManager> ()[0];

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
		myText.text = line;
		workingText = new string[myText.text.Length];
		for (int i = 0; i < myText.text.Length; i++) {
			workingText [i] = myText.text.ToCharArray () [i].ToString ();
		}
		counter = 0;
		dying = false;
	}

	// Update is called once per frame
	void FixedUpdate ()
	{     
		PlayerPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
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
			scoreManager.incScore ();
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.Equals (player)) {
			if (hurtOnlyOnce) {
				player.GetComponent<Player>().hurt();
				hurtOnlyOnce = false;
			}

			Destroy(this.gameObject);
		};

	}

	public void giveFocus ()
	{
		hasFocus = true;
		myText.color = Color.yellow;
	}

	public void letFocus ()
	{
		hasFocus = false;
		myText.color = Color.white;
	}
}
