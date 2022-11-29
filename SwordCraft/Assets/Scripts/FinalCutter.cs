using UnityEngine;

public class FinalCutter : MonoBehaviour
{
    [SerializeField] private GameObject[] _slicers;
    [SerializeField] private Transform[] _transforms;

    private int _scliceCounter = 0;

    private void Start()
    {
        int SlicePositionCounter = 0;

        for (int i = 0; i < _slicers.Length; i++)
        {
            _slicers[i].transform.position = new Vector3((_transforms[0 + SlicePositionCounter].position.x + _transforms[1 + SlicePositionCounter].position.x) / 2,
                transform.position.y,
                (_transforms[0 + SlicePositionCounter].position.z + _transforms[1 + SlicePositionCounter].position.z) / 2);

            if (i % 2 == 1)
                SlicePositionCounter++;
        }

        _slicers[0].transform.rotation = Quaternion.Euler(new Vector3(0, GetAngel(0, 1), 130));
        _slicers[1].transform.rotation = Quaternion.Euler(new Vector3(0, GetAngel(0, 1), 50));
        _slicers[2].transform.rotation = Quaternion.Euler(new Vector3(0, GetAngel(1, 1), 130));
        _slicers[3].transform.rotation = Quaternion.Euler(new Vector3(0, GetAngel(1, 1), 50));
        _slicers[4].transform.rotation = Quaternion.Euler(new Vector3(0, -1 * GetAngel(1, 1) -180, 130));
        _slicers[5].transform.rotation = Quaternion.Euler(new Vector3(0, -1 * GetAngel(1, 1) -180, 50));
        _slicers[6].transform.rotation = Quaternion.Euler(new Vector3(0, 180 - GetAngel(0, 1), 130));
        _slicers[7].transform.rotation = Quaternion.Euler(new Vector3(0, 180 - GetAngel(0, 1), 50));
    }

    private void Update()
    {
        if (_scliceCounter < 8)
            _slicers[_scliceCounter++].GetComponent<Slicer>().Slice();
        else 
            gameObject.SetActive(false);
    }

    private float GetAngel(int slicePositionCounter, int direction)
    {
        return direction * (180 / Mathf.PI) * Mathf.Atan(((_transforms[0 + slicePositionCounter].position.x - _transforms[1 + slicePositionCounter].position.x)) / (_transforms[0 + slicePositionCounter].position.z - _transforms[1 + slicePositionCounter].position.z));
    }
}
