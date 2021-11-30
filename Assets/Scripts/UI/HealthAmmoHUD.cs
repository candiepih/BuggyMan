using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthAmmoHUD : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        [SerializeField] private Image ammoBar;
        private PlayerManager _pm;
        
        // Start is called before the first frame update
        void Start()
        {
            _pm = PlayerManager.Instance;
        }

        private void LateUpdate()
        {
            UpdateGamePlayData();
        }

        private void UpdateGamePlayData()
        {
            healthBar.fillAmount = _pm.health / _pm.maxHealth;
            ammoBar.fillAmount = _pm.ammo / _pm.maxAmmo;
        }
    }
}
