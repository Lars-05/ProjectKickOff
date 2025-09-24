using System;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private void Awake()
    {
        InvokeRepeating("SaveData", 60f, 60);
    }

    private void SaveData()
    {
        GetUserData.SaveUserSaveData();
    }
}
