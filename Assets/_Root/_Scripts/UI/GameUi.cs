using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Root._Scripts.UI
{
    public class GameUi : MonoBehaviour
    {
        public void BackToMenu()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
        }
    }
}
