using UnityEngine;

public class LevelUIController : MonoBehaviour
{
    [SerializeField] private GameObject[] _stars;
    [SerializeField] private int _lvlIndex;
    [SerializeField] private GameObject _lock;

    private void Start()
    {
        for (int i = 0; i < PlayerPrefs.GetInt(_lvlIndex.ToString()); i++)
        {
            _stars[i].SetActive(true);
        }
    }

    public void DeleteLock()
    {
        _lock.SetActive(false);
    }
}
