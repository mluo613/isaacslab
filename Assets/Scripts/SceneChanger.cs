using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown ("1")) {
			Globals.uiMode = "None";
			SceneManager.LoadScene ("balldrop");
		}
		if (Input.GetKeyDown ("2")) {
			Globals.uiMode = "None";
			SceneManager.LoadScene ("NEWcannonshot");
		}
		if (Input.GetKeyDown ("3")) {
			Globals.uiMode = "None";
			SceneManager.LoadScene ("towerDrop");
		}
	}
}
