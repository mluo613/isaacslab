using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScatterPlot : MonoBehaviour {

    private SortedDictionary<float, Vector3> positionPoints = new SortedDictionary<float, Vector3>();
    private SortedDictionary<float, Vector3> velocityPoints = new SortedDictionary<float, Vector3>();
    private SortedDictionary<float, Vector3> accelerationPoints = new SortedDictionary<float, Vector3>();

    private Mechanics mechanicsScript;

    public float timeAxisFactor = 8f;
    public float positionAxisFactor;
    public bool timerStarted = true;
    public float timeInterval;
    public int numberPointsCollected;
    public float timeElapsed;

    private Vector3 initialVelocity;

    // Use this for initialization
    void Start () {

        mechanicsScript = GetComponent<Mechanics>();

        initialVelocity = mechanicsScript.velocity;

        numberPointsCollected = 1; // need to initalize in start as global didn't initalize it...
        timeInterval = 0.1f;
        timeElapsed = 0;

        positionPoints.Add(0, new Vector3(0,this.transform.localPosition.y, 0));
        positionAxisFactor = 20/this.transform.localPosition.y;
        plotPoint(positionPoints[0].y, new UnityEngine.Color(0, 0, 250));
        velocityPoints.Add(0, Vector3.zero);
        accelerationPoints.Add(0, Vector3.zero);
    }

    void plotPoint(float pointPosition, UnityEngine.Color color)
    {
        // use cube
        GameObject point = Instantiate(Resources.Load("PlotPoint")) as GameObject;
        GameObject tablet = GameObject.Find("Axes");
        point.transform.SetParent(tablet.transform);
        point.transform.localPosition = new Vector3(timeInterval * numberPointsCollected * timeAxisFactor, 
                                                    pointPosition*positionAxisFactor, 0);
        point.GetComponent<MeshRenderer>().material.color = color;

    }

    // Update is called once per frame
    void Update () {
        if (timerStarted)
        {
            Vector3 velocity = mechanicsScript.velocity;
            Vector3 gravity = mechanicsScript.gravity;

            Debug.Log(0.5f * gravity);
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
                plotPoint(positionPoint.y, new UnityEngine.Color(0, 0, 250));
                plotPoint(velocity.y, new UnityEngine.Color(0, 250, 0));
                plotPoint(gravity.y, new UnityEngine.Color(250, 0, 0));

                positionPoints.Add(numberPointsCollected, positionPoint);
                velocityPoints.Add(numberPointsCollected, velocity);
                accelerationPoints.Add(numberPointsCollected, gravity);

                // draw new point on the screen

                numberPointsCollected++;

              
                Debug.Log("TIME ELAPSED: " + timeElapsed);
                for (int ii = 0; ii < positionPoints.Count; ++ii)
                {
                    Debug.Log("POINT: " + ii + ": " + positionPoints[ii]);
                }
                
            }

        }
	}
}
