using UnityEngine;
using Player;

namespace Enemy {
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 2.0f;
        private PlayerManager _pm;

        private void Start()
        {
            _pm = PlayerManager.Instance;
        }

        private void Update()
        {
            Move();
            Rotate();
        }
    
        private void Move()
        {
            var enemyTransform = transform;
            var position = enemyTransform.position;
            var direction = _pm.transform.position - position;
            position += direction.normalized * moveSpeed * Time.deltaTime;
            enemyTransform.position = position;
        }

        private void Rotate()
        {
            var direction = _pm.transform.position - transform.position;
            transform.rotation = Quaternion.Euler(0, direction.normalized.x > 0 ? 180 : 0, 0);
        }
    }
}
