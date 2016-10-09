using UnityEngine;
using System.Collections;

public class StretchCylinderY : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // TODO remove this transformation!
        //this.transform.Translate(new Vector3(0, .005f, 0));

        Vector3 position = this.transform.localPosition;

        // based on position, stretch cylinder
        GameObject yCyl = GameObject.Find("StretchCylinderY");
        yCyl.transform.localScale = new Vector3(.2f, .2f+position.y, .2f);
        Debug.Log(yCyl.transform.localScale);
    }
}
