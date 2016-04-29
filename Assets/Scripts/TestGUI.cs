using UnityEngine;

public class TestGUI : MonoBehaviour {

	void OnGUI()
    {
        if(GUI.Button(new Rect(10, 10, 100, 20), "Save"))
        {
            Debug.Log("Save");
            GameSaveLoadManager.Save();
        }

        if (GUI.Button(new Rect(10, 40, 100, 20), "Load"))
        {
            Debug.Log("Load");
            Debug.Log(Application.persistentDataPath);
            GameSaveLoadManager.Load();
        }

        GUIStyle centeredStyle = new GUIStyle(GUI.skin.textArea);
        centeredStyle.alignment = TextAnchor.MiddleCenter;

        //GUI.TextArea(new Rect(10, 100, 160, 20), "Current Time: " + System.DateTime.Now.ToString("HH:mm:ss"), centeredStyle);

        if (GameData.CurrentGameData != null)
        {
            //GUI.TextArea(new Rect(10, 130, 160, 20), "Saved Time: " + GameData.CurrentGameData.saveTime.ToString("HH:mm:ss"), centeredStyle);
        }
    }
}
