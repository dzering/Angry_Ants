using UnityEngine;

namespace _Root._Scripts
{
    public class GameManager : MonoBehaviour
    {
        public GameState currentState;
        
        void Start()
        {
            currentState = GameState.Game;
        }
        
    }
    
    public enum GameState{None,Start, Game, GameOver}
}


