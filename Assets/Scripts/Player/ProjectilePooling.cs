using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;

namespace Player
{
    public class ProjectilePooling : MonoBehaviour
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform spawnLocation;
        [SerializeField] private bool collectionChecks;
        private PlayerManager _pm;

        private void Start()
        {
            _pm = PlayerManager.Instance;
            CreateObjectPool();
        }
        
        private void CreateObjectPool()
        {
            _pm.Pool = new ObjectPool<GameObject>(() => Instantiate(projectilePrefab, spawnLocation.position, Quaternion.identity),
                ResetProjectile,
                (obj) =>
                {
                    if (obj != null)
                    {
                        obj.SetActive(false);
                    }
                }, 
                Destroy,
                collectionChecks, 35, 50);
        }

        private void ResetProjectile(GameObject obj)
        {
            if (obj == null) return;
            obj.transform.position = spawnLocation.position;
            obj.SetActive(true);
            MoveProjectile(obj);
            ReturnAfterTime(obj);
        }

        private async void ReturnAfterTime(GameObject obj)
        {
            await Task.Delay(1000);
            _pm.Pool.Release(obj);
        }
        
        private void MoveProjectile(GameObject obj) {
            obj.GetComponent<Rigidbody2D>().AddForce(_pm.transform.right * 800);
        }
    }
}
