using _Root._Scripts.Logic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Root._Scripts.UI
{
    public class MenuUiHandler : MonoBehaviour
    {
        public ColorPicker colorPicker;
        private void Start()
        {
            colorPicker.Init();
            colorPicker.onChangeColor += NewColorSelected;
        }

        public void NewColorSelected(Color color)
        {
            GameDataManager.instance.teamColor = color;
            GameDataManager.instance.SaveColor();
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
    }
}