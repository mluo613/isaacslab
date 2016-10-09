using UnityEngine;
using System.Collections;

public class StretchCylinderX : MonoBehaviour {
	GameObject xCyl;

	// Use this for initialization
	void Start () {
		xCyl = GameObject.Find("StretchCylinderX");
	
	}
	
	// Update is called once per frame
	void Update () {
        // TODO remove this transformation!
        //this.transform.Translate(new Vector3(0, .005f, 0));

		Vector3 position = this.transform.parent.localPosition * 10f;

        // based on position, stretch cylinder
        xCyl.transform.localScale = new Vector3(.2f, .2f+position.y, .2f);
        Debug.Log(xCyl.transform.localScale);
    }
}
