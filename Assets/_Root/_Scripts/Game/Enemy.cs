using _Root._Scripts.Logic;
using UnityEngine;

namespace _Root._Scripts.Game
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