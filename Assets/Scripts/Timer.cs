using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public float elapsedTime = 0f;
	public bool timerOn = false;
	// Use this for initialization

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		/* if enabled motion is true 
		 *     timeron set to true
		 * else if enabled motion is false
		 *     timeron set to false
		 * 
		 * if timeron is true   
		 *     add onto elapsed time w/ dealtatime * timescale 
		 *     update the elasped text on the timer 
		 * 
		 * if grabbedObject is not null and timeron is false
		 *     set elaspedtime to zero 
		 */
		if (gameObject.GetComponent<Mechanics> ().enableMotion && !timerOn) {
			timerOn = true;
			elapsedTime = 0f;
		} else if (gameObject.GetComponent<Mechanics> ().enableMotion && timerOn) {
			elapsedTime += Time.deltaTime * Globals.timeScale;
			GameObject.Find ("Timerbox").GetComponentInChildren<TextMesh> ().text = "Time: " + elapsedTime.ToString () + " seconds";
		} else if (!gameObject.GetComponent<Mechanics> ().enableMotion && timerOn) {
			timerOn = false;
			if (elapsedTime <= 1) {
				GameObject.Find ("Timerbox").GetComponentInChildren<TextMesh> ().text = "Time: " + elapsedTime.ToString () + " seconds";
				GameObject.Find ("Timerbox").GetComponentInChildren<TextMesh> ().text = "Excellent timing!";
			} else if (elapsedTime <= 2) {
				GameObject.Find ("Timerbox").GetComponentInChildren<TextMesh> ().text = "Time: " + elapsedTime.ToString () + " seconds";
				GameObject.Find ("Timerbox").GetComponentInChildren<TextMesh> ().text = "There is a shorter way to achieve your result!";
			} else if (elapsedTime > 2) {
				GameObject.Find ("Timerbox").GetComponentInChildren<TextMesh> ().text = "Time: " + elapsedTime.ToString () + " seconds";
				GameObject.Find ("Timerbox").GetComponentInChildren<TextMesh> ().text = "Try again with a different height";
			}
		}
	}
		
}

