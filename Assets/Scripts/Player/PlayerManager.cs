using UnityEngine;
using UnityEngine.Pool;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        public enum PlayerState
        {
            Idle,
            Run,
            Attack,
            Jump
        }

        private static PlayerManager _instance;
        
        private delegate void ChangeState(PlayerState state);

        private ChangeState _myState;
        public float lookDirection;

        public static PlayerManager Instance => _instance ? _instance : (_instance = FindObjectOfType<PlayerManager>());

        public PlayerState State { get; private set; }
        public bool isGrounded;
        public Animator anim;
        public Rigidbody2D rb;
        public float health;
        public float ammo;
        public float maxHealth;
        public float maxAmmo;
        public ObjectPool<GameObject> Pool;
        public int spawnEnemiesCount;
        public AudioSource audioSource;

        public bool canTeleport;
        // private static Collision _collisionScript;
        protected CapsuleCollider2D Cc;

        // Start is called before the first frame update
        private void Start()
        {
            _myState = ChangePlayerState;
            _myState(PlayerState.Idle);
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            Cc = GetComponent<CapsuleCollider2D>();
            audioSource = GetComponent<AudioSource>();
            // _collisionScript = GetComponent<Collision>();
            health = 100.0f;
            ammo = 100.0f;
            maxHealth = 100.0f;
            maxAmmo = 100.0f;
            isGrounded = true;
            canTeleport = false;
        }

        public void ChangePlayerState(PlayerState newState)
        {
            State = newState;
        }

        private void OnDestroy()
        {
            Destroy(_instance);
        }
    }
}
