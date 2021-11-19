using Game_Manager;
using UnityEngine;

namespace UI
{
    public class GameStateHandling : MonoBehaviour
    {
        private GameManager _gm;
        // Start is called before the first frame update
        private void Start()
        {
            _gm = GameManager.Instance;
        }

        public void PauseGame()
        {
            _gm.ChangeGameState(_gm.State != GameManager.GameState.Pause
                ? GameManager.GameState.Pause
                : GameManager.GameState.Resume);
        }

        public void GameOver()
        {
            _gm.ChangeGameState(GameManager.GameState.GameOver);
        }

        public void Menu()
        {
            _gm.ChangeGameState(GameManager.GameState.Menu);
        }
    }
}
