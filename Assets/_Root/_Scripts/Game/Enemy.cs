using _Root._Scripts.Logic;
using UnityEngine;

namespace _Root._Scripts.Game
{
    public abstract class Enemy : MonoBehaviour
    {
       public GameManager Manager { get; private set; }

        public void Construct(GameManager gameManager)
        {
            this.Manager = gameManager;
        }

        protected void CheckGameState()
        {
            if (Manager.currentState != GameState.Game)
            {
                Destroy(gameObject);
            }
        }
    }
}