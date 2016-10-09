using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CannonGrabber : MonoBehaviour
{

	public SteamVR_TrackedObject trackedObj;

	Transform grabbedObject;

	float originalObjectHeight;
	float originalGrabberHeight;

	public GameObject xPower;
	public GameObject yPower;

	public GameObject projectile;


	void Awake()
	{
		trackedObj = transform.parent.parent.GetComponent<SteamVR_TrackedObject>();
	}

	void OnTriggerStay(Collider other) {
		var device = SteamVR_Controller.Input((int)trackedObj.index);

		if (other.attachedRigidbody) {
			if (grabbedObject == null && device.GetTouchDown (SteamVR_Controller.ButtonMask.Trigger)) {

				grabbedObject = other.transform.parent;
				originalObjectHeight = grabbedObject.localPosition.y;

				//only change whether you use the GRABBER x or y, rotated the object so its always using Y
				if (grabbedObject.name == "X") {

					originalGrabberHeight = this.transform.parent.parent.position.x;
				} else if (grabbedObject.name == "Y") {

					originalGrabberHeight = this.transform.parent.parent.position.y;

				} else if (grabbedObject.name == "FIRE") {
					Mechanics mechanics = projectile.GetComponent<Mechanics> ();
					projectile.transform.localPosition = Vector3.zero;
					mechanics.velocity = new Vector3 (xPower.transform.localPosition.y * 50, yPower.transform.localPosition.y * 50, 0);
					mechanics.enableMotion = true;
					projectile.GetComponent<shot> ().Fire ();
				}
			}
		}
	}

	void Update()
	{
		var device = SteamVR_Controller.Input((int)trackedObj.index);
		if (projectile.GetComponent<Mechanics> ().enableMotion == false)
			projectile.GetComponent<Mechanics> ().velocity = new Vector3 (xPower.transform.localPosition.y * 50, yPower.transform.localPosition.y * 50, 0);

		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Axis0))
		{
			if (Mathf.Abs (device.GetAxis ().x) >= 0.5f) {
				Globals.timeScale += 0.1f * Mathf.Sign (device.GetAxis ().x);
				Globals.timeScale = Mathf.Max (Mathf.Min (Globals.timeScale, 2), 0);
			}
		}
		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Grip))
		{
			if (Globals.uiMode == "None") {
				Globals.uiMode = "Overlay";
				foreach (GameObject overlay in Globals.overlays) {
					overlay.SetActive (true);
				}
			}
			else if (Globals.uiMode == "Overlay") {
				Globals.uiMode = "Velocity";
			}
			else if (Globals.uiMode == "Velocity") {
				Globals.uiMode = "Acceleration";
			}
			else if (Globals.uiMode == "Acceleration") {
				Globals.uiMode = "Solution";
				foreach (GameObject overlay in Globals.solutions) {
					overlay.SetActive (true);
				}
			}
			else if (Globals.uiMode == "Solution") {
				Globals.uiMode = "None";
				foreach (GameObject overlay in Globals.solutions) {
					overlay.SetActive (false);
				}

				Globals.solutions = new List<GameObject>();
				foreach (GameObject overlay in GameObject.FindGameObjectsWithTag("Solution")) {
					Globals.solutions.Add (overlay);
					overlay.SetActive (false);
				}
			}
		}

		if (grabbedObject != null && device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {

			if (grabbedObject.name == "X") {
				grabbedObject.localPosition = new Vector3 (grabbedObject.localPosition.x, 
					Mathf.Max(0, this.transform.parent.parent.position.x - (originalGrabberHeight - originalObjectHeight)), 
					grabbedObject.localPosition.z);
			} else if (grabbedObject.name == "Y") {
				grabbedObject.localPosition = new Vector3 (grabbedObject.localPosition.x, 
					Mathf.Max(0, this.transform.parent.parent.position.y - (originalGrabberHeight - originalObjectHeight)), 
					grabbedObject.localPosition.z);

			}

		}
		else if (grabbedObject != null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
		{
			originalObjectHeight = 0;
			originalGrabberHeight = 0;

			grabbedObject = null;
		}
	}
}
