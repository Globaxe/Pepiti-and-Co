using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	Autoscroller scroller;

	private bool isJumping;
	private bool oneJump;
	Animator anim;
	private int pdv = 3;
	private TextMesh affPdv;

	private float time;
	public float speed;
	// Use this for initialization
	void Start ()
	{
		scroller = GameObject.FindObjectsOfType<Autoscroller> () [0];
		anim = GetComponentInChildren<Animator> ();
		affPdv = GetComponentInChildren<TextMesh> ();
		setAffPdv();
		oneJump = true;
	}

	void FixedUpdate ()
	{
		Transform plateform = scroller.GetPateformPlayer ();


		if (isJumping) {
			if (oneJump) {
				anim.SetTrigger ("jump");
				oneJump = false;
			}
			if (Time.time - time < 1) {
				transform.position = Vector3.MoveTowards (transform.position, new Vector3 (0, plateform.position.y, 0) + transform.position, 1.5f * speed * Time.deltaTime);
			} else {
				transform.position = Vector3.MoveTowards (transform.position, plateform.position, speed * Time.deltaTime);
					

				if (transform.position == plateform.position) {
					anim.SetTrigger ("land");
					transform.SetParent (plateform);
					isJumping = false;
					oneJump = true;
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

	public void hurt ()
	{
		anim.SetTrigger("hit");
		pdv -= 1;
		setAffPdv ();
		if (pdv == 0) {
			OnDestroy ();
		}
	}

	public void OnDestroy ()
	{
		SceneManager.LoadScene (2);
	}

	private void setAffPdv()
	{
		affPdv.text = "";
		for (int i = 0; i < pdv; i++) {
			affPdv.text += "♥ ";
		}
	}
}

