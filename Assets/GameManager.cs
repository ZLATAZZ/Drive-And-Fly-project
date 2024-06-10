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

    [SerializeField] private Toggle front;
    [SerializeField] private Toggle back;

    

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

    public void ChooseFrontWheel()
    {
        
        if (front.isOn)
        {
            isFront = true;
            isBack = false;
            back.isOn = false;
            
        }
        
    }

    public void ChooseBackWheel()
    {
        
        if (back.isOn)
        {
            isFront = false;
            isBack = true;
            front.isOn = false;
            
        }
        
    }

    public void UpdateScene()
    {
        SceneManager.LoadScene(1);
    }

    [System.Serializable]
    public class SaveData
    {
        public bool isFront;
        public bool isBack;
    }

    public void SaveChoice()
    {
        SaveData saveData = new SaveData();
        saveData.isFront = isFront;
        saveData.isBack = isBack;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/saveddata.json", json);
    }

    public void LoadChoice()
    {
        string path = Application.persistentDataPath + "/savedata.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            saveData.isFront = isFront;
            saveData.isBack = isBack;
        }
    }
}
