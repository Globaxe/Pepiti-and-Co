using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoscroller : MonoBehaviour
{
	public int nbChilds = 6;
	public float speed = 0.05f;
	public GameObject prefab;

	private int idFocus;
	private bool wait;

	private Player player;
	// Use this for initialization
	void Start ()
	{
		idFocus = 1;
		wait = false;
		player = GameObject.FindObjectsOfType<Player> () [0];
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Scroll
		transform.position -= speed * Vector3.right;

		float width = GameObject.FindWithTag ("Ground").GetComponent<Collider> ().bounds.size.x;
		//Add child
		if (transform.childCount < nbChilds) {
			float x = width / nbChilds;
			float y = Random.Range (3, 15);
			float z = 0f;

			GameObject plat = Instantiate (prefab, new Vector3 (x * (transform.childCount + 1) - width / 2, y, z), transform.rotation);
			plat.transform.SetParent (transform);
		}

		//Destroy child
		Transform child = transform.GetChild (0);
		if (child.position.x < -width / 2) {
			Destroy (child.gameObject);
			if (!wait)
				idFocus = (idFocus == 0) ? 0 : idFocus - 1;
		}

		transform.GetChild (idFocus).GetComponent<Spawn> ().giveFocus ();

	}

	public void NextPlateform ()
	{
		speed *= 1.1f;
		player.Jump ();
		transform.GetChild (idFocus).GetComponent<Spawn> ().letFocus ();
		if (idFocus == nbChilds - 1) {
			idFocus =	nbChilds - 1;
			wait = true;
		} else {
			idFocus =	idFocus + 1;
		}
	}

	public Transform GetPateformPlayer ()
	{
		if (idFocus > 0)
			return transform.GetChild (idFocus - 1);
		return null;
	}
}
