using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DrawArrows : MonoBehaviour
{

    private float xTest = 0.0f;
    private float yTest = 0.0f;

    public GameObject Ball;
    private Mechanics mechanicsScript;

    private bool areVelocityArrowsVisible = false;
    private bool areAccelerationArrowsVisible = false;
    public List<GameObject> arrows = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        GameObject bottomOfSphere = GameObject.Find("BottomOfSphere");
        mechanicsScript = bottomOfSphere.GetComponent<Mechanics>();
    }

    void drawSingleArrow(Vector3 vector, UnityEngine.Color color)
    {
        GameObject arrow = Instantiate(Resources.Load("ArrowCont")) as GameObject;
        //arrow.gameObject.transform.position = new Vector3(xTest, 0, 0); // todo replace with object position
        float velocityMag = Mathf.Sqrt(Mathf.Pow(vector.x, 2) + Mathf.Pow(vector.y, 2));
        float rotationAngleDegrees = Mathf.Atan2(vector.y, vector.x) * 180 / Mathf.PI;
        arrow.transform.Rotate(new Vector3(0, 0, rotationAngleDegrees));

        arrow.transform.SetParent(Ball.transform);
        arrow.transform.localPosition = Vector3.zero;

        MeshRenderer[] meshArray = arrow.gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mesh in meshArray)
        {
            mesh.material.color = color;
        }

        arrow.gameObject.transform.localScale = new Vector3(velocityMag * .2f, 1 * .2f, 1 * .2f);
        arrows.Add(arrow);
    }

    void toggleArrows(List<Vector3> vectors, UnityEngine.Color color)
    {
        // if arrows are not there, draw them!
        for (int ii = 0; ii < vectors.Count; ++ii)
        {
            Vector3 vector = vectors[ii];
            Debug.Log(vector);
            // draw x and y arrows
            if (vector.x != 0)
            {
                Vector3 vecx = new Vector3(vector.x, 0, 0);
                drawSingleArrow(vecx, color);
            }

            if (vector.y != 0)
            {
                Vector3 vecy = new Vector3(0, vector.y, 0);
                drawSingleArrow(vecy, color);
            }

            // draw resultant arrow
            if (vector.x != 0 && vector.y != 0)
            {
                drawSingleArrow(vector, color);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(mechanicsScript.velocity);

        // todo -translate arrows if this is too slow
        // constantly redrawing the arrows per frame!
        // loop through all arrows and make them invisible
        for (int ii = 0; ii < arrows.Count; ++ii)
        {
            Debug.Log("hiding arrow");
            GameObject.Destroy(arrows[ii]);
        }
        arrows.Clear();

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


        if (areVelocityArrowsVisible)
        {
            List<Vector3> velocities = new List<Vector3>();
            velocities.Add(mechanicsScript.velocity);
            toggleArrows(velocities, new UnityEngine.Color(0, 0, 250));
        }

        if (areAccelerationArrowsVisible)
        {
            List<Vector3> accelerations = new List<Vector3>();
            accelerations.Add(mechanicsScript.gravity);
            accelerations.Add(mechanicsScript.handForce);
            toggleArrows(accelerations, new UnityEngine.Color(250, 0, 0));
        }

    }
}

