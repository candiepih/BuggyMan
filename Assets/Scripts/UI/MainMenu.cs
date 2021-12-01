using Game_Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        private GameManager _gm;
        [SerializeField] private GameObject helpPanel;

        private void Start()
        {
            _gm = GameManager.Instance;
        }

        public void QuitGame()
        {
            _gm.ChangeGameState(GameManager.GameState.Exit);
            Application.Quit();
        }

        public void FirstPlay()
        {
            _gm.ChangeGameState(GameManager.GameState.Play);
            SceneManager.LoadScene("Game_Scene");
        }

        public void Help()
        {
            helpPanel.SetActive(true);
        }
        
        public void CloseHelp()
        {
            helpPanel.SetActive(false);
        }
    }
}
