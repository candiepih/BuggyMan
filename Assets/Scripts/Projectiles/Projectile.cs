using Pickups;
using Player;
using UnityEngine;
using Properties = Enemy.Properties;


namespace Projectiles
{
    public class Projectile : MonoBehaviour
    {
        
        private PlayerManager _pm;
        [SerializeField] private GameObject hitEffect;

        // Start is called before the first frame update
        private void Start()
        {
            _pm = PlayerManager.Instance;
        }
        

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag("Enemy")) return;
            _pm.Pool.Release(gameObject);
            HandleParticleEffect();
            var enemyGameObject = collision.gameObject;
            var enemyProperties = enemyGameObject.GetComponent<Properties>();
            enemyProperties.health -= enemyProperties.damageAmount;

            if (!(enemyProperties.health <= 0)) return;
            enemyGameObject.GetComponent<Spawn>().SpawnPickup();
            Destroy(enemyGameObject);
            _pm.spawnEnemiesCount--;
        }
        
        private void HandleParticleEffect()
        {
            var effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }
}
