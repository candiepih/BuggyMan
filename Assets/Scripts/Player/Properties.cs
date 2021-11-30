using Game_Manager;
using UnityEngine;

namespace Player
{
    public class Properties : MonoBehaviour
    {
        private PlayerManager _pm;
        private GameManager _gm;

        // Start is called before the first frame update
        private void Start()
        {
            _pm = PlayerManager.Instance;
            _gm = GameManager.Instance;
        }

        // Update is called once per frame
        private void Update()
        {
            CheckAmmoLimit();
            CheckHealthLimit();
            HandleDeath();
        }

        private void HandleDeath()
        {
            if (_pm.health <= 0)
            {
                _gm.ChangeGameState(GameManager.GameState.GameOver);
            }
        }

        private void CheckHealthLimit()
        {
            if (_pm.health <= 0)
            {
                _pm.health = 0;
            }
            else if (_pm.health > _pm.maxHealth)
            {
                _pm.health = _pm.maxHealth;
            }
        }

        private void CheckAmmoLimit()
        {
            if (_pm.ammo <= 0)
            {
                _pm.ammo = 0;
            }
            else if (_pm.ammo > _pm.maxAmmo)
            {
                _pm.ammo = _pm.maxAmmo;
            }
        }
    }
}
