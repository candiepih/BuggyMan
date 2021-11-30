using UnityEngine;

namespace Enemy
{
    public class Properties : MonoBehaviour
    {
        [HideInInspector] public float health = 100.0f;
        public float damageAmount = 10.0f;
    }
}
