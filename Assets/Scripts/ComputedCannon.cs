using UnityEngine;
using System.Collections;

public class ComputedCannon : MonoBehaviour {

	private Mechanics mechanicsScript;

	// Use this for initialization
	void Start () {
		mechanicsScript = this.GetComponent<Mechanics>();
	}

	// Update is called once per frame
	void Update () {
		if (!mechanicsScript.enableMotion && Globals.uiMode == "Solution") {
			Vector3 gravity = mechanicsScript.gravity;
			float accelerationY = gravity.y;
			float initialPosition = 0;

			float timeToGround = 0;
			// solving for t from y = y0 + vt + 1/2at^2

			string solutions = "y = y0 + v0*t + (1/2)*a*t^2\n";
/*			solutions += "y = " + (Mathf.Round(initialPosition*1000)/1000).ToString () + " + 0*t + (1/2)*(-9.8)*t^2\n";
			solutions += "0 - " + (Mathf.Round(initialPosition*1000)/1000).ToString()  + " = 0*t + (1/2)*(-9.8)*t^2\n";
			solutions += "-" + (Mathf.Round(initialPosition*1000)/1000).ToString()  + " = (1/2)*(-9.8)*t^2\n";
			solutions += "-2*" + (Mathf.Round(initialPosition*1000)/1000).ToString()  + " = (-9.8)*t^2\n";
			solutions += " t^2 = (-2*" + (Mathf.Round(initialPosition*1000)/1000).ToString()  + ") / (-9.8)\n";
			solutions += "t = Sqrt(-2*" + (Mathf.Round(initialPosition*1000)/1000).ToString()  + "/ (-9.8))\n";
			solutions += "t = Sqrt(-2*" + (Mathf.Round(initialPosition*1000)/1000).ToString()  + "/ (-9.8))\n";
*/
			timeToGround = Mathf.Sqrt (Mathf.Abs (2 * (initialPosition) / accelerationY));

			solutions += "Time To Ground = " + (Mathf.Round(timeToGround*1000)/1000).ToString () + " sec";

			//this.transform.parent.FindChild ("Equations").GetComponentInChildren<TextMesh> ().text = equations;
			GameObject.Find ("Solutions").GetComponentInChildren<TextMesh> ().text = solutions;
		}
	}
}
