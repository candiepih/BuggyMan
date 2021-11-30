using Player;
using UnityEngine;

namespace Effects
{
    public class Parallax : MonoBehaviour
    {
        [SerializeField] private float effectAmount;

        private float _startPos, _length;

        private SpriteRenderer _sr;
        private Camera _cam;
        private PlayerManager _pm;
        
        // Start is called before the first frame update
        private void Start()
        {
            _cam = Camera.main;
            _sr = GetComponent<SpriteRenderer>();
            _length = _sr.bounds.size.x;
            _startPos = transform.position.x;
            _pm = PlayerManager.Instance;
        }

        private void LateUpdate()
        {
            ParallaxEffect();
        }

        private void ParallaxEffect()
        {
            if (_pm.lookDirection == 0) return;
            var camPosition = _cam.transform.position;
            var temp = camPosition.x * (1f - effectAmount);
            var dist = camPosition.x * effectAmount;
            var mTransform = transform;
            var pos = mTransform.position;

            if (temp > _startPos + _length)
            {
                _startPos += _length;
            }
            else if (temp < _startPos - _length)
            {
                _startPos -= _length;
            }
            mTransform.position = new Vector3(_startPos + dist, pos.y, pos.z);
        }
    }
}
