using UnityEngine;
using System.Collections;

public class Wood : MonoBehaviour {

	GameObject fire;
    bool onFire;

	[SerializeField]
	int woodAmount;
    public int WoodAmount {
        get {
            return woodAmount;
        }
        set {
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
			Vector3 tempVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			tempVec.z = 0;
			gameObject.transform.position = tempVec;
		}
		else {
            if (onFire)
            {
                fire.GetComponent<Fire>().StokeFire(woodAmount);
            }

            else
            {
                GameObject.Find("Wood Pile").GetComponent<WoodPile>().AddToWoodPileSize(1);
            }

            Destroy(gameObject);

		}
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Skeet");

        if (other.gameObject.name == "Fire")
        {
            onFire = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Skoot");

        if (other.gameObject.name == "Fire")
        {
            onFire = false;
        }
    }

}
