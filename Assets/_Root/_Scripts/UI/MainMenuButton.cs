using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Root._Scripts.UI
{
    public class MainMenuButton : MonoBehaviour
    {
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(MainMenu);
        }

        private void MainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
