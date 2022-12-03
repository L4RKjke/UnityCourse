using UnityEngine;

public class GreenLine : Line
{
    [SerializeField] private Transform _origin;
    [SerializeField] private Laser _laser;

    private readonly int  _numberOfSteps = 1000;

    private void OnDisable()
    {
        LineRenderer.positionCount = 0;
    }

    public void DrawGreenLine(Vector3 startLine, Vector3 endLine)
    {
        LineRenderer.positionCount = _numberOfSteps;

        var _xRayStep = (endLine.x - startLine.x) / _numberOfSteps;
        var _zRayStep = (endLine.z - startLine.z) / _numberOfSteps;

        Vector3 newPosition;
        RaycastHit hit;

        float curentPositionX = startLine.x;
        float curentPositionZ = startLine.z;

        for (int i = 0; i < _numberOfSteps; i++)
        {
            newPosition = new Vector3(curentPositionX, 1, curentPositionZ);
            curentPositionX += _xRayStep;
            curentPositionZ += _zRayStep;
            Physics.Raycast(newPosition, -transform.up, out hit);
            LineRenderer.SetPosition(i, new Vector3(hit.point.x - _origin.transform.position.x, hit.point.y - transform.position.y + 0.01f, hit.point.z - _origin.transform.position.z));
        }

        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}