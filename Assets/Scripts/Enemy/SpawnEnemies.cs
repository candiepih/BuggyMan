using System.Collections.Generic;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class SpawnEnemies : MonoBehaviour
    {
        [SerializeField] private List<GameObject> enemy = new List<GameObject>();
        [SerializeField] private List<GameObject> pickups = new List<GameObject>();

        public float spawnTime = 10f;
        private const float PickupsSpawnTime = 5f;
        private Vector3 _spawnPosition;
        private Vector3 _pickupsSpawnPosition;
        private PlayerManager _pm;
        private int _maxEnemies = 3;

        private void Start()
        {
            _pm = PlayerManager.Instance;
            InvokeRepeating(nameof(SpawnEnemiesPrefabs), spawnTime, spawnTime);
            InvokeRepeating(nameof(SpawnPickupsPrefabs), PickupsSpawnTime, Random.Range(15, 30));
            _maxEnemies = 3;
        }

        private void Update()
        {
            var playerPosition = _pm.transform.position;
            _spawnPosition = new Vector3(playerPosition.x + Random.Range(4, 10), 0, 0);
            _pickupsSpawnPosition = new Vector3(playerPosition.x + Random.Range(5, 10), playerPosition.y + 1, 0);
        }

        private void SpawnEnemiesPrefabs()
        {
            var spawnEnemyIndex = Random.Range(0, enemy.Count);
            _pm.spawnEnemiesCount++;
            if (_pm.spawnEnemiesCount >= _maxEnemies) return;
            Instantiate(enemy[spawnEnemyIndex], _spawnPosition, Quaternion.identity);
        }
        
        private void SpawnPickupsPrefabs()
        {
            var spawnPickupsIndex = Random.Range(0, pickups.Count);
            Instantiate(pickups[spawnPickupsIndex], _pickupsSpawnPosition, Quaternion.identity);
        }
    }
}
