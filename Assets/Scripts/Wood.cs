using UnityEngine;
using System.Collections;

public class Wood : MonoBehaviour {

	GameObject fire;

	[SerializeField]
	int woodAmount;
    public int WoodAmount
    {
        get
        {
            return woodAmount;
        }

        set
        {
            woodAmount = value;
        }
    }

    // Use this for initialization
    void Start () {
		fire = GameObject.Find("Fire");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {
			Debug.Log("down");
			Vector3 tempVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			tempVec.z = 0;
			gameObject.transform.position = tempVec;
		}
		else {
			Debug.Log("gone");
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
			//Destroy(gameObject);
		}
	}
}
