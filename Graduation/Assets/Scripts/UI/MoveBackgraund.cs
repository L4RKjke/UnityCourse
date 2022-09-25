using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]

public class MoveBackgraund : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    private RawImage _image;
    private float _imagePositionX;
    private float _imagePositionY;
    private float _prevPositionX;
    private float _prevPositionY;

    void Start()
    {
        _image = GetComponent<RawImage>();
    }

    void Update()
    {
        if (_playerTransform != null)
        {
            if (_prevPositionX != _playerTransform.position.x || _prevPositionY != _playerTransform.position.y)
            {
                var directionX = (_playerTransform.position.x - _prevPositionX);
                var directionY = (_playerTransform.position.y - _prevPositionY);

                _imagePositionX += directionX * Time.deltaTime * 10;
                _imagePositionY += directionY * Time.deltaTime * 10;

                _image.uvRect = new Rect(_imagePositionX, _imagePositionY, _image.uvRect.width, _image.uvRect.height);

                _prevPositionX = _playerTransform.position.x;
                _prevPositionY = _playerTransform.position.y;
            }
        }
    }
}
