using UnityEngine;
using System.Collections;

public class shot : MonoBehaviour {

	private AudioSource source;
	public AudioClip shots;
	public AudioClip explosion;
	public Mechanics mechanics;

	bool isFiring;

	// Use this for initialization
	void Awake () {
		source = GetComponent<AudioSource>();
		mechanics = GetComponent<Mechanics> ();
		isFiring = false;
		GameObject.Find("ResultText").GetComponentInChildren<TextMesh>().text = "";
	}


	public void Fire(){
		GameObject.Find("ResultText").GetComponentInChildren<TextMesh>().text = "";
		source.clip = shots;
		source.Play();
		isFiring = true;
	}


	void Update () {
		if (isFiring == true && mechanics.enableMotion == false) {
			isFiring = false;

			float distanceFromTarget = Mathf.Abs(this.transform.localPosition.x - 50);

			if (distanceFromTarget < 0.5f) {
				GameObject.Find ("ResultText").GetComponentInChildren<TextMesh> ().text = "Perfect shot, Newton!";
				source.clip = explosion;
				source.Play ();
			} else if (distanceFromTarget < 1.5f) {
				GameObject.Find ("ResultText").GetComponentInChildren<TextMesh> ().text = "Just one ring off!";
			} else if (distanceFromTarget < 3f) {
				GameObject.Find ("ResultText").GetComponentInChildren<TextMesh> ().text = "Almost there!";
			} else {
				GameObject.Find ("ResultText").GetComponentInChildren<TextMesh> ().text = "Try Again!!";
			}
		}
	}



}