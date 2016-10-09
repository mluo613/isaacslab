using UnityEngine;
using System.Collections;

public class ComputedSolution : MonoBehaviour {

    public GameObject BottomOfSphere;
    private Mechanics mechanicsScript;

    // Use this for initialization
    void Start () {
        GameObject bottomOfSphere = GameObject.Find("BottomOfSphere");
        mechanicsScript = BottomOfSphere.GetComponent<Mechanics>();
        Debug.Log(mechanicsScript.velocity);
    }

    float computeTimeToGround(float acceleration, float velocityY, float initialPosition)
    {
        float timeToGround = 0;

        timeToGround = Mathf.Sqrt(2 * (initialPosition) / acceleration);

        return timeToGround;
    }

	// Update is called once per frame
	void Update () {
        Debug.Log(mechanicsScript.velocity);
        Vector3 velocity = mechanicsScript.velocity;
        Vector3 gravity = mechanicsScript.gravity;
        float accelerationY = gravity.y;
        float velocityY = velocity.y;
        float initialPosition = BottomOfSphere.transform.position.y;
        float timeToGround = computeTimeToGround(accelerationY, velocityY, initialPosition);
        Debug.Log("TIME TO GROUND: " + timeToGround);
	}
}
