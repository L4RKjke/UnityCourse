using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private readonly float _xPosition = 0;
    private readonly float _yPosition = 3.5f;
    private readonly float _zPosition = -3.8f;
    private readonly float _xRotation = 30f;
    private readonly float _yRotation = 0f;

    private void Start()
    {
        transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0);
    }

    private void Update()
    {
        transform.position = _target.transform.position + new Vector3(_xPosition - _target.position.x, _yPosition, _zPosition);
    }
}
