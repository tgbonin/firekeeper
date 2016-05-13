﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Barrel : MonoBehaviour {

	float waterAmount;

	[SerializeField]
	GameObject emptyBarrel, fullBarrel;

	// Use this for initialization
	void Start () {
		waterAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (waterAmount > 2.0f) {
			fullBarrel.SetActive(true);
			emptyBarrel.SetActive(false);
		}
		else {
			emptyBarrel.SetActive(true);
			fullBarrel.SetActive(false);
		}

		GameObject.Find("WaterAmtText").GetComponent<Text>().text = waterAmount + " L";
	}

	public void AddWater(float addAmount) {
		waterAmount += addAmount;
		if (waterAmount > 10.0f) {
			waterAmount = 10.0f;
		}
		else if (waterAmount < 0.0f) {
			waterAmount = 0.0f;
		}
	}
}
