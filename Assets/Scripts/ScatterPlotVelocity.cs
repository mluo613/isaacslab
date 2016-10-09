using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScatterPlotVelocity : MonoBehaviour {

    private SortedDictionary<float, Vector3> positionPoints = new SortedDictionary<float, Vector3>();
    private SortedDictionary<float, Vector3> velocityPoints = new SortedDictionary<float, Vector3>();

    private Mechanics mechanicsScript;

	public float timeAxisFactor = 2f;
    public float positionAxisFactor;
    public bool timerStarted = true;
    public float timeInterval;
    public int numberPointsCollected;
    public float timeElapsed;

    private Vector3 initialVelocity;

	void Start(){
		mechanicsScript = GetComponent<Mechanics>();
	}
    // Use this for initialization
	public void Drop () {


        initialVelocity = mechanicsScript.velocity;

        numberPointsCollected = 1; // need to initalize in start as global didn't initalize it...
        timeInterval = 0.5f;
        timeElapsed = 0;
        positionPoints.Add(0, new Vector3(0, this.transform.localPosition.y, 0));

        positionAxisFactor = 20/120f;
        velocityPoints.Add(0, Vector3.zero);
    }

    void plotPoint(float pointPosition, UnityEngine.Color color)
    {
        // use cube
        GameObject point = Instantiate(Resources.Load("PlotPoint")) as GameObject;
        GameObject tablet = GameObject.Find("AxesVelocity");
        point.transform.SetParent(tablet.transform);
        point.transform.localPosition = new Vector3(timeInterval * numberPointsCollected * timeAxisFactor, 
			pointPosition*positionAxisFactor, 0);
		point.transform.localScale = new Vector3 (.5f, .5f, .5f);
        point.GetComponent<MeshRenderer>().material.color = color;

    }

    // Update is called once per frame
    void Update () {
		if (timerStarted && mechanicsScript.enableMotion)
        {
            // don't plot anymore past the max time
            if (timeAxisFactor * timeInterval * numberPointsCollected > 20)
            {
                return;
            }

            Vector3 velocity = mechanicsScript.velocity;
            Vector3 gravity = mechanicsScript.gravity;

            // ever x seconds (e.g. 0.5s, 1s), grab the position, velocity, and acceleration and graph them
            timeElapsed += Time.deltaTime * Globals.timeScale;
            if(timeElapsed >= timeInterval * numberPointsCollected)
            {
                Vector3 positionPoint = positionPoints[0]
                + 0.5f * gravity * Mathf.Pow(timeInterval * numberPointsCollected, 2);

                /* not needed as velocity changes from gravity
                Vector3 velocityPoint = velocityPoints[numberPointsCollected - 1]
                                    + gravity * timeInterval * numberPointsCollected;
                                    */
                if (positionPoint.y <= 0)
                {
                    plotPoint(0, new UnityEngine.Color(0, 250, 0));
                }
                else
                {
                    plotPoint((-gravity * timeInterval * numberPointsCollected).y, new UnityEngine.Color(0, 250, 0));
                }

                velocityPoints.Add(numberPointsCollected, velocity);

                // draw new point on the screen

                numberPointsCollected++;

                
            }

        }
	}
}
