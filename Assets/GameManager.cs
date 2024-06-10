using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [HideInInspector] public bool isFront;
    [HideInInspector] public bool isBack;
    [HideInInspector] public int score;

    public Toggle front;
    public Toggle back;

    

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadChoice();
        
    }

    private void Start()
    {
        LoadChoice();
        Debug.Log(Application.persistentDataPath);
    }

    

    [System.Serializable]
    public class SaveData
    {
        public bool isFront;
        public bool isBack;
        public int score;
    }

    public void SaveChoice()
    {
        SaveData saveData = new SaveData();
        saveData.isFront = isFront;
        saveData.isBack = isBack;
        saveData.score = score;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
        Debug.Log("Was Saved");
    }

    public void LoadChoice()
    {
        string path = Application.persistentDataPath + "/savedata.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            isFront = saveData.isFront;
            isBack = saveData.isBack;
            score = saveData.score;
            
            if(isFront)
            {
                front.isOn = true;
                back.isOn = false;
            }
            if(isBack)
            {
                front.isOn = false;
                back.isOn = true;
            }
        }

        
    }
}
