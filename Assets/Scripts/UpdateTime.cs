using UnityEngine;
using System.Collections;

public class UpdateTime : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		this.GetComponent<TextMesh> ().text = "TimeScale: " + Globals.timeScale.ToString ();
	}
}
