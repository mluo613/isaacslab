using UnityEngine;
using System.Collections;

public class updateVelocity : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider collide) {
	//INNER RING
		Debug.Log("trigger");
		if (collide.name == "scene_4_1to1__target_1") {
			GetComponent<TextMesh> ().text = "Bull's Eye";
		} else if (collide.name == "scene_4_1to1__target_2") {
			GetComponent<TextMesh> ().text = "Velocity is:";
		} else if (collide.name == "scene_4_1to1__target_3") {
			GetComponent<TextMesh> ().text = "Velocity is:";
		}
	}
}
