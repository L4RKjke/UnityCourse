using UnityEngine;

public class RedLine : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;

    private readonly int _maxPoints = 2;
    private readonly float _height = 0.081f;
    private readonly int _xPosition = 0;

    private void DrowRedLine(float positionZ, int PosId)
    {
        _lineRenderer.SetPosition(PosId, new Vector3(_xPosition, _height, positionZ));
    }

    public void DrowLine()
    {
        _lineRenderer.positionCount = _maxPoints;

        DrowRedLine(_start.position.z, 0); 
        DrowRedLine(_end.position.z, 1); 
    }
}