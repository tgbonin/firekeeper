using UnityEngine;

[System.Serializable]
public class GameData {

    public static GameData CurrentGameData;
    public int fireSecondsLeft;
    public System.DateTime saveTime;
    public int numWood;
    public float amtWater;

    public GameData(int secondsLeft, int wood, float water)
    {
        fireSecondsLeft = secondsLeft;
        saveTime = System.DateTime.Now;
        numWood = wood;
        amtWater = water;
    }
	
}
