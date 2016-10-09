using UnityEngine;
using System.Collections;

public class balldrop : MonoBehaviour {

	public AudioClip crashSoft;
	private AudioSource source;
	// Use this for initialization
	void Awake () {
		source = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter (Collision coll) {
		source.PlayOneShot (crashSoft, 20F);

	}

}
