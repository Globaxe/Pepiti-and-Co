using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed;
	public float horizontalspeed;
	public float jumpForce;
	private Rigidbody rb;
	private bool jumping;
	private Vector3 rotateValue;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate ()
	{
		if (!jumping) {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			float moveUp = Input.GetAxis ("Jump");

			rotateValue = new Vector3 (0, moveHorizontal * -1 * horizontalspeed, 0);
			transform.eulerAngles = transform.eulerAngles - rotateValue;


			if (Input.GetButton ("Jump")) {
				jumping = true;
			}
			Vector3 movement = transform.rotation * new Vector3 (0, 0, moveVertical);

			rb.AddForce (new Vector3 (0, moveUp * jumpForce, 0));
			rb.velocity = movement * speed;
		} else {
			if (rb.velocity.y == 0) {
				jumping = false;
			}
		}
	}
}
