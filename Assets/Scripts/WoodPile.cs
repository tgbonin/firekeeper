using UnityEngine;
using System.Collections;

public class WoodPile : MonoBehaviour {

	[SerializeField]
	GameObject logPrefab;

	int life;

	// Use this for initialization
	void Start () {
		life = 7200;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown() {
		Vector3 tempVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		tempVec.z = 0;
		Instantiate(logPrefab, tempVec, Quaternion.identity);
	}
}
