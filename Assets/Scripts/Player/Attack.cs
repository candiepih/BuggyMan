using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private GameObject muzzleFlash;
        [SerializeField] private AudioClip shootSound;
        private PlayerManager _pm;

        private void Start()
        {
            _pm = PlayerManager.Instance;
        }
        
        public void OnAttack(InputAction.CallbackContext ctx)
        {
            if (!ctx.started) return;
            if (_pm.ammo <= 0) return;
            muzzleFlash.SetActive(true);
            _pm.audioSource.PlayOneShot(shootSound);
            _pm.Pool.Get();
            _pm.ammo -= 1.0f;
            StartCoroutine(nameof(TurnMuzzleFlashOff));
        }
        
        private IEnumerator TurnMuzzleFlashOff()
        {
            yield return new WaitForSeconds(0.1f);
            muzzleFlash.SetActive(false);
        }
    }
}
