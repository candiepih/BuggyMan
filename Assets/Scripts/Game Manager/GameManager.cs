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

        void Awake()
        {
            DontDestroyOnLoad(Instance);
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
