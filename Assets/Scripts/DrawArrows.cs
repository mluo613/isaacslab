using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DrawArrows : MonoBehaviour {

    private float xTest = 0.0f;
    private float yTest = 0.0f;

    public GameObject Ball;
    private Mechanics mechanicsScript;

    private bool areArrowsVisible = false;
    public List<GameObject> arrows = new List<GameObject>();

	// Use this for initialization
	void Start () {
        GameObject bottomOfSphere = GameObject.Find("BottomOfSphere");
        mechanicsScript = bottomOfSphere.GetComponent<Mechanics>();
        Debug.Log(mechanicsScript.velocity);
        Debug.Log(Ball);
    }
	
    void drawSingleArrow(Vector3 objectPosition, Vector3 vector)
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
            mesh.material.color = new UnityEngine.Color(0, 0, 250);
        }
        //arrow.gameObject.GetComponent<MeshRenderer>().material.color = new UnityEngine.Color(0, 0, 0);
        //arrow.gameObject.GetComponentInChildren<Transform>().Find("Cylinder").localScale = new Vector3(1,2,1);
        arrow.gameObject.transform.localScale = new Vector3(velocityMag*.2f, 1*.2f, 1*.2f);
        // TODO - need to adjust base of cylinder
        Debug.Log(rotationAngleDegrees);
        arrows.Add(arrow);
    }

    void toggleArrows(Vector3 objectPosition, List<Vector3> velocities, List<Vector3> accelerations)
    {
        if (areArrowsVisible == false)
        {
            areArrowsVisible = true;
            // if arrows are not there, draw them!
            for (int ii = 0; ii < velocities.Count; ++ii)
            {
                Vector3 velocity = velocities[ii];
                Debug.Log(velocity);
                // draw x and y arrows
                if (velocity.x != 0)
                {
                    Vector3 velx = new Vector3(velocity.x, 0, 0);
                    drawSingleArrow(objectPosition, velx);

                }

                if (velocity.y != 0)
                {
                    Vector3 vely = new Vector3(0, velocity.y, 0);
                    drawSingleArrow(objectPosition, vely);

                }

                // draw resultant arrow
                if (velocity.x != 0 && velocity.y != 0)
                {
                    drawSingleArrow(objectPosition, velocity);
                }
                
            }
            for (int ii = 0; ii < accelerations.Count; ++ii)
            {
                yTest += 1f;
                GameObject arrow2 = Instantiate(Resources.Load("Arrow")) as GameObject;
                arrow2.gameObject.transform.position = new Vector3(yTest,0,0);
                arrows.Add(arrow2);
            }


        }
        else
        {
            areArrowsVisible = false;
            // loop through all arrows and make them invisible
            for(int ii=0; ii<arrows.Count; ++ii)
            {
                Debug.Log("hiding arrow");
                GameObject.Destroy(arrows[ii]);
            }
            arrows.Clear();
        }
    }

	// Update is called once per frame
	void Update () {
        Debug.Log(mechanicsScript.velocity);

        if (Input.GetKeyDown("d"))
        {
            Vector3 objectPosition = new Vector3(0, 0, 0);
            List<Vector3> velocities = new List<Vector3>();
            velocities.Add(mechanicsScript.velocity);
            List<Vector3> accelerations = new List<Vector3>(); ;
            //accelerations.Add(new Vector3(0, 0, 0));
            toggleArrows(objectPosition, velocities, accelerations);
        }

        // show arrows
        for (int ii = 0; ii < arrows.Count; ++ii)
        {
            //xTest += 1f;
            //arrows[ii].gameObject.transform.position = new Vector3(xTest,0,0);
        }

    }
}
