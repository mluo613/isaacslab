using UnityEngine;
using System.Collections;

public class Mechanics : MonoBehaviour {
	public Vector3 velocity = new Vector3 (0, 0, 0);

	public bool enableMotion = true;

	// Use this for initialization
	void Start () {
		
	}


	// Update is called once per frame
	void Update () {


		if (enableMotion) {
			// v = v0 + at
			velocity.y += Time.deltaTime * Globals.timeScale * -9.8f;

			if (this.transform.localPosition.y <= 0) {
				velocity.y = 0;
				this.transform.localPosition = 
					new Vector3 (this.transform.localPosition.x, 0, this.transform.localPosition.z);
			}
			else {
				this.transform.Translate (velocity * Time.deltaTime * Globals.timeScale);
			}
		}

	}
}
