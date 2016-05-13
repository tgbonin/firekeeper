using UnityEngine;
using System.Collections;

public class Bucket : MonoBehaviour {

	bool full, pickedUp = false;
	Vector3 startPos;

	[SerializeField]
	GameObject emptyBucket, fullBucket;

	// Use this for initialization
	void Start () {
		startPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (pickedUp) {
			Vector3 tempVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			tempVec.z = 0;
			gameObject.transform.position = tempVec;
		}
	}

	void OnMouseDown() {
		pickedUp = true;
	}

	void OnMouseUp() {
		pickedUp = false;
		gameObject.transform.position = startPos;
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		Debug.Log("Skeet");

		if (other.gameObject.name == "Water")
		{
			full = true;
			emptyBucket.SetActive(false);
			fullBucket.SetActive(true);
		}
		else if (other.gameObject.name == "Barrel")
		{
			full = false;
			emptyBucket.SetActive(true);
			fullBucket.SetActive(false);
			GameObject.Find("Barrel").GetComponent<Barrel>().AddWater(1.0f);
		}
	}
}
