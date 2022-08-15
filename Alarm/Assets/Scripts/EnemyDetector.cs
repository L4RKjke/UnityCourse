using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    public bool IsSomebodyIn { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsSomebodyIn = (collision.TryGetComponent(out Character player));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsSomebodyIn = !(collision.TryGetComponent(out Character player));
    }
}