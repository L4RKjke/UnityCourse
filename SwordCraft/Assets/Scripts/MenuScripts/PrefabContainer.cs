using UnityEngine;

public class PrefabContainer : MonoBehaviour
{
    [SerializeField] private GameObject[] _handles;
    [SerializeField] private Texture[] _backgrounds;

    public static GameObject[] SwordHandles { get; private set; }

    public static Texture[] Backgrounds { get; private set; }

    private void Awake()
    {
        SwordHandles = _handles;
        Backgrounds = _backgrounds;
    }
}
