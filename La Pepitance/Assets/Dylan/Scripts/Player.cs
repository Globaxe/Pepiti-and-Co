using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
	Autoscroller scroller;

	private bool isJumping;

	private float time;
	public float speed;
	// Use this for initialization
	void Start ()
	{
		scroller = GameObject.FindObjectsOfType<Autoscroller> () [0];
	}

	void FixedUpdate ()
	{
		Transform plateform = scroller.GetPateformPlayer ();


		if (isJumping) {
			if (Time.time - time < 1) {
				transform.position = Vector3.MoveTowards (transform.position, new Vector3 (0, plateform.position.y, 0) + transform.position, 1.5f * speed * Time.deltaTime);
			} else {
				transform.position = Vector3.MoveTowards (transform.position, plateform.position, speed * Time.deltaTime);
					

				if (transform.position == plateform.position) {
					
					transform.SetParent (plateform);
					isJumping = false;
				}

			}
		}
	}

	public void Jump ()
	{
		transform.SetParent (null);
		if (!isJumping)
			time = Time.time;
		isJumping = true;
	}
}

