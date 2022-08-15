using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    public event EnemyInZoneEvent EnemyInZone;

    public delegate void EnemyInZoneEvent(bool argumnent);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyInZone?.Invoke((collision.TryGetComponent(out Character player)));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemyInZone?.Invoke(!(collision.TryGetComponent(out Character player)));
    }
}