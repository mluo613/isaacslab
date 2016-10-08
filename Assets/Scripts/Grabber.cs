using UnityEngine;
using System.Collections;

public class Grabber : MonoBehaviour
{

	public SteamVR_TrackedObject trackedObj;
	FixedJoint joint;

	Transform grabbedObject;

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
				
				grabbedObject = other.transform.parent;

				originalObjectHeight = grabbedObject.localPosition.y;
				originalGrabberHeight = this.transform.parent.parent.position.y;

				grabbedObject.GetComponent<Mechanics> ().enableMotion = false;
				grabbedObject.GetComponent<Mechanics> ().velocity.y = 0;
			}
		}
	}

	void Update()
	{
		var device = SteamVR_Controller.Input((int)trackedObj.index);

		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Axis0))
		{
			if (Mathf.Abs (device.GetAxis ().x) >= 0.5f) {
				Globals.timeScale += 0.25f * Mathf.Sign (device.GetAxis ().x);
				Globals.timeScale = Mathf.Max (Mathf.Min (Globals.timeScale, 2), 0);
			}
		}

		if (grabbedObject != null && device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
			
			grabbedObject.localPosition = new Vector3 (grabbedObject.localPosition.x, 
				Mathf.Max(0, this.transform.parent.parent.position.y - (originalGrabberHeight - originalObjectHeight)), 
				grabbedObject.localPosition.z);
			
		}
		else if (grabbedObject != null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
		{
			originalObjectHeight = 0;
			originalGrabberHeight = 0;

			grabbedObject.GetComponent<Mechanics> ().enableMotion = true;
			grabbedObject = null;
		}
	}
}
