using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;
using System.Threading.Tasks;
using Quaternion = UnityEngine.Quaternion;

namespace Player
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private GameObject projectilePrefab;

        [SerializeField] private Transform spawnLocation;
        private bool collectionChecks = true;
        private PlayerManager _pm;

        private void Start()
        {
          _pm = PlayerManager.Instance;
            CreateObjectPool();
        }

        public void OnAttack(InputAction.CallbackContext ctx)
        {
            if (ctx.started)
            {
                _pm.pool.Get();
            }
        }

        private void CreateObjectPool()
        {
            _pm.pool = new ObjectPool<GameObject>(() => Instantiate(projectilePrefab, spawnLocation.position, Quaternion.identity),
                                           (obj) => { 
                                               // Take from pool
                                               ResetProjectile(obj);
                                               },
                                           (obj) => obj.SetActive(false),  (obj) => Destroy(obj),
                                           collectionChecks, 15, 20);
        }

        private void ResetProjectile(GameObject obj)
        {
            obj.transform.position = spawnLocation.position;
            obj.SetActive(true);
            MoveProjectile(obj);
            ReturnAfterTime(obj);
        }

        private async void ReturnAfterTime(GameObject obj)
        {
            await Task.Delay(1000);
            _pm.pool.Release(obj);
        }

        private void MoveProjectile(GameObject obj) {
            obj.GetComponent<Rigidbody2D>().AddForce(_pm.transform.right * 800);
        }
    }
}
