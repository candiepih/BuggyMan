using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Projectile : MonoBehaviour
{
    private PlayerManager _pm;

    // Start is called before the first frame update
    void Start()
    {
        _pm = PlayerManager.Instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _pm.pool.Release(gameObject);
            var EnemyGameObject = collision.gameObject;
            var attack = EnemyGameObject.GetComponent<Attack>();
            attack.health -= attack.damageAmount;
            if (attack.health <= 0)
            {
                Destroy(EnemyGameObject);
            }
        }
    }
}
