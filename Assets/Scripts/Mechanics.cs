using UnityEngine;
using System.Collections;

public class Mechanics : MonoBehaviour {
	private Vector3 velocity = new Vector3 (0, 0, 0);

	public bool enableMotion = false;


	// Use this for initialization
	void Start () {

		velocity.x = 5f;
		velocity.y = 10f;

	}

	void reset(string Test) {
		Debug.Log ("RESET");
		velocity.x = 5f;
		velocity.y = 10f;
		this.transform.localPosition = Vector3.zero;
		Debug.Log (Test);
	
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (this.transform.position.y);


		if (Input.GetKeyDown("space"))
			enableMotion = !enableMotion;

		if (Input.GetKeyDown ("r")) {
			reset ("test");
		}

		if (enableMotion) {
			// v = v0 + at
			velocity.y += Time.deltaTime * -9.8f;


			this.transform.Translate (velocity * Time.deltaTime);
		}
	}
}
