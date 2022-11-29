using UnityEngine;

public class HandleGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _handleParent;

    private void Start()
    {
        Instantiate(PrefabContainer.SwordHandles[PlayerPrefs.GetInt("CurrentHandle")], transform.position, Quaternion.identity).transform.SetParent(_handleParent.transform, true);
    }
}