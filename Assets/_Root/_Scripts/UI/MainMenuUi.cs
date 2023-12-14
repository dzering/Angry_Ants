using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Root._Scripts.UI
{
    public class MainMenuUi : MonoBehaviour
    {
        public void PlayGame() => 
            SceneManager.LoadScene(1);

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