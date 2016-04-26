using UnityEngine;

[System.Serializable]
public class GameData {

    public static GameData CurrentGameData;
    public System.DateTime saveTime;

    public GameData()
    {
        saveTime = System.DateTime.Now;
    }
	
}
