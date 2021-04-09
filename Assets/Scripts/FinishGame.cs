using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SaveGame(other);

            SceneManager.LoadScene("Menu");
        }
    }

    void SaveGame(Collider2D other)
    {
        // PlayerPrefs
        PlayerPrefs.SetString("PlayerName", other.name);
        PlayerPrefs.SetString("PlayerTag", other.tag);
        PlayerPrefs.Save();

        //persistentDataPath
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file;

        if (File.Exists(Application.persistentDataPath + "/gameInformation.dat"))
        {
            file = File.OpenWrite(Application.persistentDataPath
                     + "/gameInformation.dat");
        }
        else
        {
            file = File.Create(Application.persistentDataPath
                     + "/gameInformation.dat");
        }

        PlayerData data = new PlayerData();
        data.playerName = "PlayerName";
        data.playerTag = "PlayerTag";


        bf.Serialize(file, data);
        file.Close();

        Debug.Log("Game data saved!");
    }

    [Serializable]
    public class PlayerData
    {
        public string playerName;
        public string playerTag;
    }
}
