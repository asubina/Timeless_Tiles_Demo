using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class SaveData
{
    public bool[] isActive;
    public int[] highScore;
    public int[] stars;
}

public class GameData : MonoBehaviour
{
    public static GameData gameData;
    public SaveData saveData;

    void Awake()
    {
        if (gameData == null)
        {
            DontDestroyOnLoad(this.gameObject);
            gameData = this;
            InitializeSaveData(); // Ensure saveData is initialized
            Load();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        // Additional start logic if needed
    }

    private void InitializeSaveData()
    {
        saveData = new SaveData();
        saveData.isActive = new bool[100];
        saveData.stars = new int[100];
        saveData.highScore = new int[100];
        saveData.isActive[0] = true;
        saveData.isActive[3] = true;
        saveData.isActive[6] = true;
    }

    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/player.dat", FileMode.Create);
        formatter.Serialize(file, saveData);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/player.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/player.dat", FileMode.Open);
            saveData = formatter.Deserialize(file) as SaveData;
            file.Close();
        }
        else
        {
            InitializeSaveData(); // Initialize with default values
        }

        EnsureDefaultLevelsActive(); // Ensure levels 0, 3, and 6 are active
    }

    private void EnsureDefaultLevelsActive()
    {
        saveData.isActive[0] = true;
        saveData.isActive[3] = true;
        saveData.isActive[6] = true;
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnDisable()
    {
        Save();
    }

    public void ResetData()
    {
        if (File.Exists(Application.persistentDataPath + "/player.dat"))
        {
            File.Delete(Application.persistentDataPath + "/player.dat");
        }
        InitializeSaveData(); // Reset to default values
        Save(); // Save the reset data
    }

    void Update()
    {
        // Update logic if needed
    }
}
