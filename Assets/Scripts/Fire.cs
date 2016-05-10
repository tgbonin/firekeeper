﻿using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	int life;
	GameObject woodPile;

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
