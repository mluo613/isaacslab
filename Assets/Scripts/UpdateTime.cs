using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UpdateTime : MonoBehaviour {
	void Awake() {
		Globals.overlays = new List<GameObject>();
		foreach (GameObject overlay in GameObject.FindGameObjectsWithTag("Overlay")) {
			Globals.overlays.Add (overlay);
			overlay.SetActive (false);
		}

	}
	// Update is called once per frame
	void Update () {
		this.GetComponent<TextMesh> ().text = "TimeScale: " + (Mathf.Round(Globals.timeScale*10)/10f).ToString ();
	}
}
