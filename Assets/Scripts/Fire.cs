using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	int life;

	// Use this for initialization
	void Start () {
		life = 300;
        InvokeRepeating("FireCountdown", 1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (life <= 0) {
			Debug.Log("The fire has died!");
			Destroy(gameObject);
		}
	}

    public void FireCountdown()
    {
        life--;
    }

	public void StokeFire(int addSeconds) {
		life += addSeconds;
	}

    public int secondsLeft()
    {
        return life;
    }

    public void setSecondsLeft(int s)
    {
        life = s;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("colliding");
        StokeFire(coll.gameObject.GetComponent<Wood>().WoodAmount);
        Destroy(coll.gameObject);
    }
}
