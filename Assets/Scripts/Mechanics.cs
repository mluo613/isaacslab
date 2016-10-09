using UnityEngine;
using System.Collections;

public class Mechanics : MonoBehaviour {
	public Vector3 velocity = new Vector3 (0, 0, 0);

	public bool enableMotion = true;

	public Vector3 gravity = new Vector3 (0, -9.8f, 0);
	public Vector3 handForce = new Vector3 (0, 9.8f, 0);

	// Use this for initialization
	void Start () {
	}


	// Update is called once per frame
	void Update () {

        // when f key  is pressed
        if (Input.GetKey("f"))
        {
            enableMotion = true;
        }

		if (enableMotion) {
            // Need to get initial velocity from the settings of the balls on the table

			// v = v0 + at
			velocity.y += Time.deltaTime * Globals.timeScale * -9.8f;

			if (this.transform.localPosition.y <= 0 && velocity.y <= 0) {
				velocity.y = 0;
				enableMotion = false;
				AudioSource audioSource = GetComponentInChildren<AudioSource> ();
				audioSource.Play();
				this.transform.localPosition = 
					new Vector3 (this.transform.localPosition.x, 0, this.transform.localPosition.z);
			}
			else {
				this.transform.Translate (velocity * Time.deltaTime * Globals.timeScale);
			}

		}

	}
}
