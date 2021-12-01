using UnityEngine;

namespace Game_Manager
{
    public class GameManager : MonoBehaviour
    {
        public enum GameState
        {
            Exit,
            Play,
            Menu,
            GameOver,
            Pause,
            Resume
        }

        public GameState State
        {
            get;
            private set;
        }
        private static GameManager _instance;
        public bool gameWon;
        public string gameLostText;
        public string gameWonText;

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<GameManager>();
                }

                return _instance;
            }
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            gameWon = false;
            gameLostText = "Not all good stories have a happy ending.";
            gameWonText = "Luckily he escaped the place.";
        }

        public void ChangeGameState(GameState newState)
        {
            State = newState;
        }

        public void OnDestroy()
        {
            Destroy(_instance);
        }
    }
}
