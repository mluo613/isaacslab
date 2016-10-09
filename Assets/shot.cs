using UnityEngine;
using System.Collections;

public class shot : MonoBehaviour {

	private AudioSource source;
	public AudioClip shots;
	public Rigidbody r;
	public AudioClip explosion;

	// Use this for initialization
	void Awake () {
		source = GetComponent<AudioSource>();
	}

	void Start () {
		r = GetComponent<Rigidbody> ();
		// Update is called once per frame
		GameObject.Find("ResultText").GetComponentInChildren<TextMesh>().text = "";
	}

	void Update () {
		if (Input.GetButtonDown("Fire1")) // add in trigger for 
		{
			r.velocity = Vector3.down;
			source.PlayOneShot (shots, 5F);
			GameObject.Find("ResultText").GetComponentInChildren<TextMesh>().text = "";
		}

	}

	void OnCollisionEnter (Collision coll) {
		
		source.PlayOneShot (explosion, 1F);  
		if (coll.gameObject.name == "scene_4_1to1__target_1") {
			GameObject.Find("ResultText").GetComponentInChildren<TextMesh>().text = "Perfect shot, Newton!";
		} else if (coll.gameObject.name == "scene_4_1to1__target_2") {
			GameObject.Find("ResultText2").GetComponentInChildren<TextMesh>().text = "Just one ring off!";
		} else if (coll.gameObject.name == "scene_4_1to1__target_3") {
			GameObject.Find("ResultText3").GetComponentInChildren<TextMesh>().text = "At least on the edge of target!";
		}
		transform.localPosition = new Vector3 (0, 0, 0);
		r.velocity = Vector3.zero;
	}



}