using System.Collections;
using Player;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Pickups
{
    public class PortalSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject portalPrefab;
        private Vector2 _playerStartPosition;
        private PlayerManager _pm;
        private bool _activePortal;
        
        private void Start()
        {
            _pm = PlayerManager.Instance;
            _playerStartPosition = _pm.transform.position;
            InvokeRepeating(nameof(SpawnPortal), 5, 5);
        }
        
        private void SpawnPortal()
        {
            var distance = Vector2.Distance(_pm.transform.position, _playerStartPosition);

            if (!(distance > 200) || !(_pm.transform.position.x > 0) || _activePortal) return;
            _activePortal = true;
            var playerTransform = _pm.transform;
            var playerPosition = playerTransform.position;
            var spawnPos = new Vector3(playerPosition.x + 15, playerPosition.y - 0.5f, 0);
            var portal = Instantiate(portalPrefab, spawnPos, Quaternion.identity);
            StartCoroutine(DestroyAfterTime(portal));
        }

        private IEnumerator DestroyAfterTime(Object portal)
        {
            yield return new WaitForSeconds(30);
            Destroy(portal);
            yield return new WaitForSeconds(30);
            _activePortal = false;
        }
    }
}
