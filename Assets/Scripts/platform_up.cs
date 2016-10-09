using UnityEngine;
using System.Collections;

public class platform_up : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("y"))
        {
            Vector3 position = this.transform.localPosition;
            this.transform.localPosition = new Vector3(position.x, position.y + 1, position.z);
        }

        if (Input.GetKeyDown("h"))
        {
            Vector3 position = this.transform.localPosition;
            this.transform.localPosition = new Vector3(position.x, position.y - 1, position.z);
        }
    }


    /* hint:
     *
    Vector3 position = transform.position;
    position.y = 10;
    Instantiate(HousingObject[1], position, transform.rotation);
    */   


}
