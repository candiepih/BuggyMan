using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Enemy {
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 2.0f;
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
            Vector3 direction = _pm.transform.position - transform.position;
            transform.position += direction.normalized * _moveSpeed * Time.deltaTime;
        }

        private void Rotate()
        {
            Vector3 direction = _pm.transform.position - transform.position;
            if (direction.normalized.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}
