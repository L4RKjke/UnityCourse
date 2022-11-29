using UnityEngine;

public class FinalLaser : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Transform _target;


    private void OnEnable ()
    {
        DrawLaserRay(transform.position);
    }

    private void DrawLaserRay(Vector3 startPosition)
    {
        _lineRenderer.SetPosition(0, startPosition);
       _lineRenderer.SetPosition(1, _target.position);
    }
}
