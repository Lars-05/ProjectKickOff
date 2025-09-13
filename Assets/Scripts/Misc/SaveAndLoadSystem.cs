using System.IO;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveAndLoadSystem
{
    public static void SaveData(TaskCardData[] taskCardData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/userData.grd";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, taskCardData);
        stream.Close();
    }

    public static TaskCardData[] LoadData()
    {
        string path = Application.persistentDataPath + "/userData.grd";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            TaskCardData[] taskCardData = formatter.Deserialize(stream) as TaskCardData[];
            stream.Close();
            return taskCardData; 
        }
        else
        {
            Debug.Log("Save File Not Found Or Not Made Yet");
            return null;
        }
    }
}


