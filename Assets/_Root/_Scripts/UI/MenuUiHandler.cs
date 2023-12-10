using _Root._Scripts.Data;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Root._Scripts.UI
{
    public class MenuUiHandler : MonoBehaviour
    {
        public TMP_InputField playerNameInputField; 
        public ColorPicker colorPicker;
        private void Start()
        {
            colorPicker.Init();
            colorPicker.onChangeColor += NewColorSelected;

            playerNameInputField.onEndEdit.AddListener(SavePlayerName);
            playerNameInputField.text = GameDataSingleton.instance.playerName;
        }

        public void NewColorSelected(Color color)
        {
            GameDataSingleton.instance.teamColor = color;
            GameDataSingleton.instance.SaveColor();
        }

        public void StartGame() => 
            SceneManager.LoadScene(sceneBuildIndex: 1);

        public void Exit()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        }

        private void SavePlayerName(string playerName)
        {
            GameDataSingleton instance = GameDataSingleton.instance;
            instance.SavePlayerName(playerName);
            instance.playerName = playerName;
        }
    }
}