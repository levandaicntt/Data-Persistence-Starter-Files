using UnityEngine;
using System.IO;
public class MenuData : MonoBehaviour
{
    [System.Serializable]
    public class DataSave
    {
        public string name;
        public int score;
    }
    public static MenuData instance;
    public DataSave highScoreData;
    public DataSave presentData;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }

    public void SaveData(DataSave save)
    {
        string path = Application.persistentDataPath + "/menuData.json";
        string json = JsonUtility.ToJson(save);
        File.WriteAllText(path, json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/menuData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            JsonUtility.FromJsonOverwrite(json, highScoreData);
        }
    }
}
