using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
	public void ChangeToScene (int id)
	{
		SceneManager.LoadScene (id);
	}

	public void QuitGame ()
	{
		Application.Quit ();
	}
}
