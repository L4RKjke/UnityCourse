using UnityEngine;

public class HandleGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _handleParent;
    [SerializeField] private HandlesContainer _handleContainer;

    private void Start()
    {
        Instantiate(_handleContainer.SwordHandles[PlayerPrefs.GetInt(AllStrings.CurrentHandle)], transform.position, Quaternion.identity).transform.SetParent(_handleParent.transform, true);
    }
}