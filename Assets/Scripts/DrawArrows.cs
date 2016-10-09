using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DrawArrows : MonoBehaviour
{

    private float xTest = 0.0f;
    private float yTest = 0.0f;
	public float arrowScale	 = 0.1f;

    private int velArrowCount = 0;
    private int accArrowCount = 0;

    private Mechanics mechanicsScript;

    private bool areVelocityArrowsVisible = false;
    private bool areAccelerationArrowsVisible = false;
    public List<GameObject> arrowsVelocity = new List<GameObject>();
    public List<GameObject> arrowsAcc = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        //GameObject bottomOfSphere = GameObject.Find("BottomOfSphere");
        mechanicsScript = GetComponent<Mechanics>();

        velArrowCount = 3;
        accArrowCount = 2;

        for(int ii=0; ii<velArrowCount; ++ii)
        {
            GameObject arrow = Instantiate(Resources.Load("ArrowCont")) as GameObject;
            arrow.gameObject.transform.localScale = new Vector3(0, 0, 0);
            arrowsVelocity.Add(arrow);
        }

        for (int ii = 0; ii < accArrowCount; ++ii)
        {
            GameObject arrow = Instantiate(Resources.Load("ArrowCont")) as GameObject;
            arrow.gameObject.transform.localScale = new Vector3(0, 0, 0);
            arrowsAcc.Add(arrow);
        }
    }

    void updateSingleArrowVel(Vector3 vector, UnityEngine.Color color)
    {
        float velocityMag = Mathf.Sqrt(Mathf.Pow(vector.x, 2) + Mathf.Pow(vector.y, 2));
        float rotationAngleDegrees = Mathf.Atan2(vector.y, vector.x) * 180 / Mathf.PI;
        arrowsVelocity[velArrowCount].transform.localRotation = Quaternion.Euler(0, 0, rotationAngleDegrees);

        arrowsVelocity[velArrowCount].transform.SetParent(this.transform);
        arrowsVelocity[velArrowCount].transform.localPosition = new Vector3 (0, 0.25f, 0); 

        MeshRenderer[] meshArray = arrowsVelocity[velArrowCount].gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mesh in meshArray)
        {
            mesh.material.color = color;
        }

        arrowsVelocity[velArrowCount].gameObject.transform.localScale = new Vector3(velocityMag * arrowScale, arrowScale, arrowScale);
    }

    void updateArrowsVelocity(List<Vector3> vectors, UnityEngine.Color color)
    {
        velArrowCount = 0;
        // if arrows are not there, draw them!
        for (int ii = 0; ii < vectors.Count; ++ii)
        {
            Vector3 vector = vectors[ii];
            // draw x and y arrows
            if (vector.x != 0)
            {
                Vector3 vecx = new Vector3(vector.x, 0, 0);
                updateSingleArrowVel(vecx, color);
                velArrowCount++;
            }

            if (vector.y != 0)
            {
                Vector3 vecy = new Vector3(0, vector.y, 0);
                updateSingleArrowVel(vecy, color);
                velArrowCount++;
            }

            // draw resultant arrow
            if (vector.x != 0 && vector.y != 0)
            {
                updateSingleArrowVel(vector, color);
                velArrowCount++;
            }

        }

        // There is a max of 3 vel vectors
        for (int ii=velArrowCount; ii<3; ++ii)
        {
            arrowsVelocity[ii].gameObject.transform.localScale = new Vector3(0, 0, 0);
        }
    }


    void updateSingleArrowAcc(Vector3 vector, UnityEngine.Color color)
    {
        float velocityMag = Mathf.Sqrt(Mathf.Pow(vector.x, 2) + Mathf.Pow(vector.y, 2));
        float rotationAngleDegrees = Mathf.Atan2(vector.y, vector.x) * 180 / Mathf.PI;
        arrowsAcc[accArrowCount].transform.localRotation = Quaternion.Euler(0, 0, rotationAngleDegrees);

        arrowsAcc[accArrowCount].transform.SetParent(this.transform);
        arrowsAcc[accArrowCount].transform.localPosition = new Vector3(0, 0.5f, 0);

        MeshRenderer[] meshArray = arrowsAcc[accArrowCount].gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mesh in meshArray)
        {
            mesh.material.color = color;
        }

        arrowsAcc[accArrowCount].gameObject.transform.localScale = new Vector3(velocityMag * arrowScale, arrowScale, arrowScale);
    }

    void updateArrowsAcc(List<Vector3> vectors, UnityEngine.Color color)
    {
        accArrowCount = 0;
        // if arrows are not there, draw them!
        for (int ii = 0; ii < vectors.Count; ++ii)
        {
            Vector3 vector = vectors[ii];
            // draw x and y arrows
            if (vector.x != 0)
            {
                Vector3 vecx = new Vector3(vector.x, 0, 0);
                updateSingleArrowAcc(vecx, color);
                accArrowCount++;
            }

            if (vector.y != 0)
            {
                Vector3 vecy = new Vector3(0, vector.y, 0);
                updateSingleArrowAcc(vecy, color);
                accArrowCount++;
            }

            // draw resultant arrow
            if (vector.x != 0 && vector.y != 0)
            {
                updateSingleArrowAcc(vector, color);
                accArrowCount++;
            }

        }

        // there is a max of 2 acc arrows
        for (int ii = accArrowCount; ii < 2; ++ii)
        {
            arrowsAcc[ii].gameObject.transform.localScale = new Vector3(0, 0, 0);
        }
		/*
        for (int ii = 0; ii < 2; ++ii)
        {
            Debug.Log(arrowsAcc[ii].gameObject.transform.localScale);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Debug.Log(mechanicsScript.velocity);

        if (Input.GetKeyDown("v"))
        {
            if(areAccelerationArrowsVisible)
            {
                areAccelerationArrowsVisible = false;
            }

            if (areVelocityArrowsVisible == true)
            {
                areVelocityArrowsVisible = false;
            }
            else
            {
                areVelocityArrowsVisible = true;
            }
        }

        if (Input.GetKeyDown("a"))
        {
            if(areVelocityArrowsVisible)
            {
                areVelocityArrowsVisible = false;
            }
            if (areAccelerationArrowsVisible == true)
            {
                areAccelerationArrowsVisible = false;
            }
            else
            {
                areAccelerationArrowsVisible = true;
            }
        }
		*/

		if (Globals.uiMode == "Velocity")
        {
            List<Vector3> velocities = new List<Vector3>();
            velocities.Add(mechanicsScript.velocity);
            updateArrowsVelocity(velocities, new UnityEngine.Color(0, 0, 250));
        }
        else
        {
            // max 3 vectors for velocity
            for (int ii = 0; ii < 3; ++ii)
            {
                arrowsVelocity[ii].gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
        }

		if (Globals.uiMode == "Acceleration")
        {
            List<Vector3> accelerations = new List<Vector3>();
            accelerations.Add(mechanicsScript.gravity);
			if (mechanicsScript.enableMotion == false)
	            accelerations.Add(mechanicsScript.handForce);
            updateArrowsAcc(accelerations, new UnityEngine.Color(250, 0, 0));
        }
        else
        {
            // max 2 vectors for acceleration
            for (int ii = 0; ii < 2; ++ii)
            {
                arrowsAcc[ii].gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
        }

    }
}

