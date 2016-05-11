using UnityEngine;
using System.Collections;
using System;

public class Fire : MonoBehaviour {

	int life;
	GameObject woodPile;

    TimeSpan fireTimer;

	// Use this for initialization
	void Start () {
		life = 300;
		woodPile = GameObject.Find("Wood Pile");
        InvokeRepeating("FireCountdown", 1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (life <= 0) {
			Debug.Log("The fire has died!");
			Destroy(gameObject);
		}

        fireTimer = TimeSpan.FromSeconds(life);
        string fireTime = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                        fireTimer.Hours,
                                        fireTimer.Minutes,
                                        fireTimer.Seconds
                                        );

        gameObject.GetComponentInChildren<TextMesh>().text = fireTime;

    }

    public void FireCountdown()
    {
        life--;
    }

	public void StokeFire(int stokeAmmount) {
		life += stokeAmmount;
	}

    public int secondsLeft()
    {
        return life;
    }

    public void setSecondsLeft(int s)
    {
        life = s;
    }
}
