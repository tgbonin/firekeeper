using UnityEngine;
using System.Collections;

public class Wood : MonoBehaviour {

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
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {
			Vector3 tempVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			tempVec.z = 0;
			gameObject.transform.position = tempVec;
		}
		else {
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
		}
	}
}
