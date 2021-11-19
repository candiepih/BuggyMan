using UnityEngine;
using UnityEngine.InputSystem;
using Quaternion = UnityEngine.Quaternion;

namespace Player
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private GameObject projectilePrefab;

        [SerializeField] private Transform spawnLocation;

        public void OnAttack(InputAction.CallbackContext ctx)
        {
            if (ctx.started)
            {
                EngageEnemies();
            }
        }

        private void EngageEnemies()
        {
            var instantiatedObj = Instantiate(projectilePrefab, spawnLocation.position, Quaternion.identity);
            instantiatedObj.GetComponent<Rigidbody2D>().AddForce(transform.right * 100);
        }
    }
}
