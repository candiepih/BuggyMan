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
        // private static Collision _collisionScript;
        protected CapsuleCollider2D Cc;
        public ObjectPool<GameObject> pool;

        // Start is called before the first frame update
        private void Start()
        {
            _myState = ChangePlayerState;
            _myState(PlayerState.Idle);
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            Cc = GetComponent<CapsuleCollider2D>();
            // _collisionScript = GetComponent<Collision>();
            isGrounded = true;
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
