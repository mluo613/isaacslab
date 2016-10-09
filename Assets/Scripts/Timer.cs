using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public float elapsedTime = 0f;
	public float targetTime = 0.5f;
	public bool timerOn = false;
	// Use this for initialization
	private Mechanics mechanicsScript;
	void Awake()
	{
		//GameObject bottomOfSphere = GameObject.Find("BottomOfSphere");
		mechanicsScript = GetComponent<Mechanics> ();
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
		if (mechanicsScript.enableMotion && !timerOn) {
			timerOn = true;
			elapsedTime = 0f;
		} else if (mechanicsScript.enableMotion && timerOn) {
			elapsedTime += Time.deltaTime * Globals.timeScale;
			GameObject.Find ("Timerbox").GetComponentInChildren<TextMesh> ().text = "Time: " +  (Mathf.Round(elapsedTime*1000)/1000).ToString () + " seconds";
		} else if (!mechanicsScript.enableMotion && timerOn) {
			timerOn = false;
			GameObject.Find ("Timerbox").GetComponentInChildren<TextMesh> ().text = "Time: " +  (Mathf.Round(elapsedTime*1000)/1000).ToString () + " seconds";
			if (Mathf.Abs(elapsedTime -targetTime) <= .01f) {
				GameObject.Find ("Timerbox").GetComponentInChildren<TextMesh> ().text += "\nExcellent timing!";
			} else if (Mathf.Abs(elapsedTime -targetTime) <= .03f) {
				GameObject.Find ("Timerbox").GetComponentInChildren<TextMesh> ().text += "\nThere is a shorter way to achieve your result!";
			} else {
				GameObject.Find ("Timerbox").GetComponentInChildren<TextMesh> ().text += "\nTry again with a different height!";
			}
		}
	}
		
}

