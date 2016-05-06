using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraPanSnap : MonoBehaviour {

    int desiredSnapIndex;
    List<Transform>snapPositions;

    public float timeToMove = 1.0f;
    float timeMoveStart = 0;

	// Use this for initialization
	void Start () {

        snapPositions = new List<Transform>();

        snapPositions.Add(GameObject.FindGameObjectWithTag("cameraPositions").transform.GetChild(0));
        snapPositions.Add(GameObject.FindGameObjectWithTag("cameraPositions").transform.GetChild(1));
        snapPositions.Add(GameObject.FindGameObjectWithTag("cameraPositions").transform.GetChild(2));

        desiredSnapIndex = 1;
    }
	
	// Update is called once per frame
	void Update () {
	    if(transform.position != snapPositions[desiredSnapIndex].position)
        {
            float lerpF = (Time.time - timeMoveStart) / (timeToMove);
            transform.position = Vector3.Lerp(transform.position, snapPositions[desiredSnapIndex].position, lerpF);
        }
	}

    public void SnapLeft()
    {
        if(desiredSnapIndex > 0)
        {
            desiredSnapIndex--;
            timeMoveStart = Time.time;
        }
    }

    public void SnapRight()
    {
        if(desiredSnapIndex < snapPositions.Count - 1)
        {
            desiredSnapIndex++;
            timeMoveStart = Time.time;
        }
    }
}
