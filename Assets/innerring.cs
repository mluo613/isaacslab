using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class innerring : MonoBehaviour {

	// Use this for initialization
	bool impact = false;
	void OnTriggerEnter(Collider crash) 
	{
		impact = true;
		Debug.Log ("set true");
	}

	void OnGui() {
		Debug.Log ("calling");
		if (impact) {
			Debug.Log ("loop");
			GUI.Box (new Rect (0,0, Screen.width/8, Screen.height/8), "Perfect Shot, Newton!");
		}
	}

	void OnTriggerExit(Collider crash)
	{
		impact = false;
	}
		
}
