using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private GameObject _character;

    private void Update()
    {
        if (_character != null)
            transform.position = new Vector3(_character.transform.position.x, _character.transform.position.y, -1f);
    }
}