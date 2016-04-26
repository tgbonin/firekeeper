using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	int life;

	// Use this for initialization
	void Start () {
		life = 7200;
	}
	
	// Update is called once per frame
	void Update () {
		life--;
		Debug.Log(life);
		if (life <= 0) {
			Debug.Log("The fire has died!");
			Destroy(gameObject);
		}
	}

	public void StokeFire(int woodAmount) {
		life += woodAmount;
	}
}
