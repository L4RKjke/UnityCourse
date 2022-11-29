using UnityEngine;

public class Handle : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _image;

    public int Id => _id;

    public string Name => _name;

    public Sprite Image => _image;
}
