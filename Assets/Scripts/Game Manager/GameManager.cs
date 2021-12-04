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
        [HideInInspector] public int id;

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
            id = Instance.id++;
            gameLostText = "Not all good stories have a happy ending.";
            gameWonText = "Luckily he escaped the place.";
        }

        private void Start()
        {
            CheckOtherInstances();
        }

        public void ChangeGameState(GameState newState)
        {
            State = newState;
        }

        public void OnDestroy()
        {
            Destroy(_instance);
        }
        
        private void CheckOtherInstances()
        {
            var objs = FindObjectsOfType<GameManager>();
            foreach (var gameManager in objs)
            {
                if (gameManager.id != 0)
                {
                    Destroy(gameManager.gameObject);
                }
            }
        }
    }
}
