using System;
using System.IO;
using UnityEngine;

namespace _Root._Scripts.Logic
{
    public class GameDataManager : MonoBehaviour
    {
        public Color teamColor;
        public static GameDataManager instance;
        
        private void Awake()
        {
            if(instance != null)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            LoadColor();
            DontDestroyOnLoad(gameObject);
        }
        
        [Serializable]
        public class PlayerData
        {
            public Color teamColor;
        }

        public void SaveColor()
        {
            PlayerData playerData = new PlayerData();
            playerData.teamColor = teamColor;

            string json = JsonUtility.ToJson(playerData);
            File.WriteAllText(Application.persistentDataPath + "saveFile.json", json);
        }

        public void LoadColor()
        {
            string path = Application.persistentDataPath + "saveFile.json";
            if(!File.Exists(path))
                return;

            string readAllText = File.ReadAllText(path);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(readAllText);
            teamColor = playerData.teamColor;
        }
    }
}
