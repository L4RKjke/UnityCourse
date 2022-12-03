using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;

    public LineRenderer LineRenderer => _lineRenderer;
}
