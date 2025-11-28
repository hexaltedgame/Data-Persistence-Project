using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string Name;
    public string BestScoreName;
    public int BestScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Load();
    }

    [System.Serializable]
    class SaveData
    {
        public string BestScoreName;
        public int BestScore;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.BestScoreName = BestScoreName;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/DataPersistenceProject_savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/DataPersistenceProject_savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScoreName = data.BestScoreName;
            BestScore = data.BestScore;
        }
    }


}
