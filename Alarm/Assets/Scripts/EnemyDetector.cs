using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    public event EnemyInZoneEvent EnemyInZone;

    public delegate void EnemyInZoneEvent(bool argumnent);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.TryGetComponent(out Character player)))
            EnemyInZone?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.TryGetComponent(out Character player)))
            EnemyInZone?.Invoke(false);
    }
}