using UnityEngine;
using System.Collections;
using System;

public class MobileGameManager : MonoBehaviour {

    int fireTimeLeft;
    TimeSpan fireTimer;
    GameObject fire;

	// Use this for initialization
	void Start () {
        fire = GameObject.FindGameObjectWithTag("fire");

        GameSaveLoadManager.Load();
        int secondsPassed = FindSecondsSinceLastSession();
        fire.GetComponent<Fire>().setSecondsLeft(GameData.CurrentGameData.fireSecondsLeft - secondsPassed);
	}

    private int FindSecondsSinceLastSession()
    {
        TimeSpan timeSinceLastSession = DateTime.Now.Subtract(GameData.CurrentGameData.saveTime);
        int secondsSinceLastSession = (int)timeSinceLastSession.TotalSeconds;
        return secondsSinceLastSession;
    }

    // Update is called once per frame
    void Update () {
        fireTimeLeft = fire.GetComponent<Fire>().secondsLeft();
	}

    void OnGUI()
    {
    }


    void OnApplicationQuit()
    {
        GameSaveLoadManager.Save();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            GameSaveLoadManager.Save();
        }
        else
        {
            GameSaveLoadManager.Load();
            int secondsPassed = FindSecondsSinceLastSession();
            fire.GetComponent<Fire>().setSecondsLeft(GameData.CurrentGameData.fireSecondsLeft - secondsPassed);
        }
    }

}
