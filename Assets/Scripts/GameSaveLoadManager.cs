using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameSaveLoadManager{

    public static GameData savedData;

    public static void Save()
    {
        GameData.CurrentGameData = new GameData(
            GameObject.FindGameObjectWithTag("fire").GetComponent<Fire>().secondsLeft(),
            GameObject.Find("Wood Pile").GetComponent<WoodPile>().GetAmtWoodLeft(),
            GameObject.Find("Barrel").GetComponent<Barrel>().getAmtWaterLeft()            
            );

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Create(Application.persistentDataPath + "/fireKeeperSave.save");
        bf.Serialize(fs, GameData.CurrentGameData);
        fs.Close();
    }

    public static void Load()
    {
        Debug.Log(Application.persistentDataPath);

        if (File.Exists(Application.persistentDataPath + "/fireKeeperSave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + "/fireKeeperSave.save", FileMode.Open);
            GameData.CurrentGameData = (GameData)bf.Deserialize(fs);
            fs.Close();
        }
        else
        {
            GameData.CurrentGameData = new GameData(300, 5, 3.0f);
        }
    }
}
