// This complete script can be attached to a camera to make it 
// continuously point at another object.

// The target variable shows up as a property in the inspector. 
// Drag another object onto it to make the camera look at it.
using UnityEngine;
using System.Collections;

public class TextOverlay : MonoBehaviour {
	public Transform target;

	void Update() {
		// Rotate the camera every frame so it keeps looking at the target 
		transform.LookAt(target);
		if (this.name == "VelocityOverlay") {
			GetComponentInChildren<TextMesh> ().text = "Y Velocity:" + (Mathf.Round (this.transform.parent.GetComponent<Mechanics> ().velocity.y * 10) / 10f).ToString ();
		}
		else if (this.name == "HeightOverlay") {
			GetComponentInChildren<TextMesh> ().text = "Height:" + (Mathf.Round (this.transform.parent.parent.localPosition.y * 10) / 10f).ToString ();
		}
		else if (this.name == "PowerMeter") {
			GetComponentInChildren<TextMesh> ().text = "Velocity: " + (Mathf.Round (this.transform.parent.localPosition.y * 500) / 10f).ToString () + " m/s";
		}
	}
}