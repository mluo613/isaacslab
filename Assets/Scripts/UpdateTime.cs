using UnityEngine;
using System.Collections;

public class UpdateTime : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		this.GetComponent<TextMesh> ().text = "TimeScale: " + (Mathf.Round(Globals.timeScale*10)/10f).ToString ();
	}
}
