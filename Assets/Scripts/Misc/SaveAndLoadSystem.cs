using System.IO;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveAndLoadSystem
{
    
    public static void SaveData(SaveData Data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/userData.grd";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, Data);
        stream.Close();
    }

    public static SaveData LoadData()
    {
        string path = Application.persistentDataPath + "/userData.grd";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveData saveData = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return saveData; 
        }
        else
        {
            Debug.Log("Save File Not Found Or Not Made Yet");
            return null;
        }
    }
}


