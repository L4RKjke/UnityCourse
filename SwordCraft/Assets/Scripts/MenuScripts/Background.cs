using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Background : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private int _price;

    public int Id => _id;

    public int Price => _price;

    public Sprite Image => GetComponent<SpriteRenderer>().sprite;
}
