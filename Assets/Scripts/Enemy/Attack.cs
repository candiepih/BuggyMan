using System.Collections;
using Player;
using UnityEngine;

namespace Enemy
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private float damage;
        private PlayerManager _pm;
        private bool _hasAttacked;

        private void Start()
        {
            _pm = PlayerManager.Instance;
        }

        private void Update()
        {
            if (!_hasAttacked)
            {
                DamagePlayer();
            }
        }

        private void DamagePlayer()
        {
            if (!(Vector2.Distance(transform.position, _pm.transform.position) < 1.5f)) return;
            _hasAttacked = true;
            _pm.health -= damage;
            StartCoroutine(WaitNextAttack());
        }

        private IEnumerator WaitNextAttack()
        {
            yield return new WaitForSeconds(1f);
            _hasAttacked = false;
        }
    }
}
