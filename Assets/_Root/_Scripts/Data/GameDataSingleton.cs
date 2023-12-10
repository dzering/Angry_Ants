using System.IO;
using UnityEngine;

namespace _Root._Scripts.Data
{
    public class GameDataSingleton : MonoBehaviour
    {
        public Color teamColor;
        public static GameDataSingleton instance;
        public int score;
        public string playerName;
        public BestResult bestResult;

        private void Awake()
        {
            if(instance != null)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            LoadColor();
            LoadPlayerData();
            
            bestResult = LoadBestResult();
            
            DontDestroyOnLoad(gameObject);
        }

        private void OnDestroy()
        {
            SaveBestResult();
        }

        public void SaveBestResult()
        {
            if(score < bestResult.score)
                return;

            bestResult.score = score;
            bestResult.name = playerName;
            string json = JsonUtility.ToJson(bestResult);
            File.WriteAllText(Application.persistentDataPath + "bestPlayer.json", json);
        }


        private BestResult LoadBestResult()
        {
            string path = Application.persistentDataPath + "bestPlayer.json";
            if(!File.Exists(path))
                return new BestResult(){name = playerName, score = 0};

            string allText = File.ReadAllText(path);
            return JsonUtility.FromJson<BestResult>(allText);
        }


        public void SavePlayerName(string playerName)
        {
            PlayerData playerData = new PlayerData();
            playerData.playerName = playerName;

            string json = JsonUtility.ToJson(playerData);
            string path = Application.persistentDataPath + "playerData.json";
            File.WriteAllText(path, json);
        }

        public void LoadPlayerData()
        {
            string path = Application.persistentDataPath + "playerData.json";
            if(!File.Exists(path))
                return;

            string readAllText = File.ReadAllText(path);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(readAllText);
            playerName = playerData.playerName;
        }

        public void SaveColor()
        {
            GameData gameData = new GameData();
            gameData.teamColor = teamColor;

            string json = JsonUtility.ToJson(gameData);
            File.WriteAllText(Application.persistentDataPath + "saveFile.json", json);
        }

        public void LoadColor()
        {
            string path = Application.persistentDataPath + "saveFile.json";
            if(!File.Exists(path))
                return;

            string readAllText = File.ReadAllText(path);
            GameData gameData = JsonUtility.FromJson<GameData>(readAllText);
            teamColor = gameData.teamColor;
        }
    }
}
