using UnityEngine;

public class HandlesContainer : MonoBehaviour
{
    [SerializeField] private Handle[] _handles;

    public Handle[] SwordHandles => _handles;
}