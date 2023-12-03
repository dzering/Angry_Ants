using UnityEngine;

namespace _Root._Scripts
{
    public class Enemy : MonoBehaviour
    {
        [HideInInspector] public GameManager gameManager;

        private void Start()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
    }
}