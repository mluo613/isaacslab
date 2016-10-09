using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown ("1"))
			SceneManager.LoadScene ("balldrop");

		if (Input.GetKeyDown ("2"))
			SceneManager.LoadScene ("cannonshot");
		
	}
}
