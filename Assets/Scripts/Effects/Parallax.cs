using System;
using Player;
using UnityEngine;

namespace Effects
{
    public class Parallax : MonoBehaviour
    {
        private Transform _cameraTransform;
        private Vector3 _lastCameraPosition;
        [SerializeField] private float parallax;
        private SpriteRenderer _sr;
        private float _textureUnitSizeX;
        
        private void Start()
        {
            _sr = GetComponent<SpriteRenderer>();
            if (Camera.main is { }) _cameraTransform = Camera.main.transform;
            _lastCameraPosition = _cameraTransform.position;
            var sprite = _sr.sprite;
            _textureUnitSizeX = sprite.texture.width / sprite.pixelsPerUnit;
        }
        
        private void LateUpdate()
        {
            var camPosition = _cameraTransform.position;
            var delta = camPosition - _lastCameraPosition;
            transform.position += delta * parallax;
            _lastCameraPosition = camPosition;

            if (Mathf.Abs(camPosition.x - transform.position.x) >= _textureUnitSizeX)
            {
                var offsetPosition = (camPosition.x - transform.position.x) % _textureUnitSizeX;
                transform.position = new Vector3(camPosition.x + offsetPosition, transform.position.y, transform.position.z);
            }
        }
        
        
        // [SerializeField] private float effectAmount;
        //
        // private float _startPos, _length;
        //
        // private SpriteRenderer _sr;
        // private Camera _cam;
        // private PlayerManager _pm;
        //
        // // Start is called before the first frame update
        // private void Start()
        // {
        //     _cam = Camera.main;
        //     _sr = GetComponent<SpriteRenderer>();
        //     _length = _sr.bounds.size.x;
        //     _startPos = transform.position.x;
        //     _pm = PlayerManager.Instance;
        // }
        //
        // private void LateUpdate()
        // {
        //     ParallaxEffect();
        // }
        //
        // private void ParallaxEffect()
        // {
        //     if (_pm.lookDirection == 0) return;
        //     var camPosition = _cam.transform.position;
        //     var temp = camPosition.x * (1f - effectAmount);
        //     var dist = camPosition.x * effectAmount;
        //     var mTransform = transform;
        //     var pos = mTransform.position;
        //
        //     Debug.Log("temp is " +temp);
        //     Debug.Log("Startpos + length is" + (_startPos + _length));
        //     if (temp > _startPos + _length)
        //     {
        //         _startPos += _length;
        //     }
        //     else if (temp < _startPos - _length)
        //     {
        //         _startPos -= _length;
        //     }
        //     mTransform.position = new Vector3(_startPos + dist, pos.y, pos.z);
        // }
    }
}
