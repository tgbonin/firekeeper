using UnityEngine;

[System.Serializable]
public class GameData {

    public static GameData CurrentGameData;
    public int fireSecondsLeft;
    public System.DateTime saveTime;

    public GameData(int secondsLeft)
    {
        fireSecondsLeft = secondsLeft;
        saveTime = System.DateTime.Now;
    }
	
}
