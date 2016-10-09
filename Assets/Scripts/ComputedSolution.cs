using UnityEngine;
using System.Collections;

public class ComputedSolution : MonoBehaviour {

    private Mechanics mechanicsScript;

    // Use this for initialization
    void Start () {
        mechanicsScript = this.GetComponent<Mechanics>();
    }

    float computeTimeToGround(float acceleration, float velocityY, float initialPosition)
    {
        float timeToGround = 0;
        // solving for t from v = y0 + vt + 1/2at^2
        timeToGround = Mathf.Sqrt(Mathf.Abs(2 * (initialPosition) / acceleration));

        return timeToGround;
    }

	// Update is called once per frame
	void Update () {
        Vector3 velocity = mechanicsScript.velocity;
        Vector3 gravity = mechanicsScript.gravity;
        float accelerationY = gravity.y;
        float velocityY = velocity.y;
        float initialPosition = this.transform.localPosition.y;
        float timeToGround = computeTimeToGround(accelerationY, velocityY, initialPosition);
        Debug.Log("TIME TO GROUND: " + timeToGround);
	}
}
