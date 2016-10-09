using UnityEngine;
using System.Collections;

public class ExperimentGrabber : MonoBehaviour
{

	public SteamVR_TrackedObject trackedObj;
	FixedJoint joint;

	GameObject grabbedObject;

	float originalObjectHeight;
	float originalGrabberHeight;


	void Awake()
	{
		trackedObj = transform.parent.parent.GetComponent<SteamVR_TrackedObject>();
	}

	void OnTriggerStay(Collider other) {
		var device = SteamVR_Controller.Input((int)trackedObj.index);

		if (other.attachedRigidbody) {
			if (grabbedObject == null && device.GetTouchDown (SteamVR_Controller.ButtonMask.Trigger)) {

				grabbedObject = GameObject.Find(other.name + "Drop");

				grabbedObject.GetComponent<Mechanics> ().enableMotion = true;

				grabbedObject.GetComponent<ScatterPlotPosition> ().Drop();
				grabbedObject.GetComponent<ScatterPlotVelocity> ().Drop();
				grabbedObject.GetComponent<ScatterPlotAcceleration> ().Drop();

				grabbedObject.GetComponent<ScatterPlotPosition> ().timerStarted = true;
				grabbedObject.GetComponent<ScatterPlotVelocity> ().timerStarted = true;
				grabbedObject.GetComponent<ScatterPlotAcceleration> ().timerStarted = true;
			}
		}
	}

	void Update()
	{
		var device = SteamVR_Controller.Input((int)trackedObj.index);

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
				Globals.uiMode = "None";
				foreach (GameObject overlay in Globals.solutions) {
					overlay.SetActive (false);
				}
			}
		}
		/*
		if (grabbedObject != null && device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
			float newAngle = 0f;
			if (this.transform.parent.parent.position.y <= originalGrabberHeight)
				newAngle = Mathf.Asin (this.transform.parent.parent.position.y - (originalGrabberHeight - originalObjectHeight)) - 90;

			grabbedObject.parent.localRotation = new Quaternion (
				Mathf.Max(0,newAngle),
				0,0,0
				);

		}*/
		if (grabbedObject != null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
		{

			grabbedObject = null;
		}
	}
}
