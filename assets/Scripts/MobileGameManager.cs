using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class MobileGameManager : MonoBehaviour {

    int fireTimeLeft;
    TimeSpan fireTimer;
    GameObject fire;

	float hydration;
	Scrollbar hydrationBar;
	Text hydrationTimer;
	Button hydrateButton;

	// Use this for initialization
	void Start () {
        fire = GameObject.FindGameObjectWithTag("fire");

		hydration = 1800.0f;
		hydrationBar = GameObject.Find("HydrationBar").GetComponent<Scrollbar>();
		hydrationTimer = GameObject.Find("HydrationTimer").GetComponent<Text>();
		hydrateButton = GameObject.Find("SecondCanvas").GetComponentInChildren<Button>();
		hydrateButton.onClick.AddListener(delegate { Hydrate(); });

        GameSaveLoadManager.Load();
        int secondsPassed = FindSecondsSinceLastSession();

        int secondsLeft = GameData.CurrentGameData.fireSecondsLeft - secondsPassed;

        if (secondsLeft < 0)
        {
            GameData.CurrentGameData = new GameData(300, 5, 3.0f);
            secondsLeft = 300;
        }

        Debug.Log(secondsLeft);

        fire.GetComponent<Fire>().setSecondsLeft(secondsLeft);
        GameObject.Find("Wood Pile").GetComponent<WoodPile>().SetWoodPileSize(GameData.CurrentGameData.numWood);
        GameObject.Find("Barrel").GetComponent<Barrel>().SetWaterAmt(GameData.CurrentGameData.amtWater);

        if(GameData.CurrentGameData.amtWater == 0)
        {
            GameObject.Find("HydrateButton").GetComponent<Button>().interactable = false;
        }

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

		hydration -= Time.deltaTime;
		hydrationBar.size = hydration / 1800.0f;

		string minSec = String.Format("{0}:{1:00}", (int)hydration/60, (int)hydration % 60);

		hydrationTimer.text = minSec;
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

	public void Hydrate() {
		hydration = 1800.0f;
		Debug.Log("Hydrated");
	}
}
