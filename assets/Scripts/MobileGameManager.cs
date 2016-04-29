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
        GUIStyle centeredStyle = new GUIStyle(GUI.skin.textArea);
        centeredStyle.alignment = TextAnchor.MiddleCenter;
        centeredStyle.fontSize = 35;

        fireTimer = TimeSpan.FromSeconds(fireTimeLeft);
        string fireTime = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                        fireTimer.Hours,
                                        fireTimer.Minutes,
                                        fireTimer.Seconds                                        
                                        );

        GUI.TextArea(new Rect((Screen.width / 2) - 175, 30, 350, 60), "Time Left: " + fireTime, centeredStyle);
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
