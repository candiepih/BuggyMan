using System;
using Game_Manager;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace UI
{
    public class GamePlayActions : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private TextMeshProUGUI gameOverMessageText;
        private GameManager _gm;
        
        // Start is called before the first frame update
        private void Start()
        {
            _gm = GameManager.Instance;
        }

        // Update is called once per frame
        private void Update()
        {
            HandleUIEvents();
        }

        private void HandleUIEvents()
        {
            switch (_gm.State)
            {
                case GameManager.GameState.Menu:
                    GoToMenu();
                    break;
                case GameManager.GameState.GameOver:
                    GameOverPanel();
                    break;
                case GameManager.GameState.Pause:
                    PausePanel();
                    break;
                case GameManager.GameState.Resume:
                    ResumeGame();
                    break;
                case GameManager.GameState.Exit:
                    break;
                case GameManager.GameState.Play:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ResumeGame()
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }

        private void PausePanel()
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }

        private void GameOverPanel()
        {
            gameOverMessageText.text = _gm.gameWon ? _gm.gameWonText : _gm.gameLostText;
            gameOverPanel.SetActive(true);
        }

        private void GoToMenu()
        {
            SceneManager.LoadScene("Menu");
        }

        public void Replay()
        {
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
