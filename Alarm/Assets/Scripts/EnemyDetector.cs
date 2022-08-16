using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    public event EnemyInZoneEvent EnemyInZone;

    public delegate void EnemyInZoneEvent(bool argumnent);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (EnemyInZone is not null)
            EnemyInZone.Invoke((collision.TryGetComponent(out Character player)));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (EnemyInZone is not null)
            EnemyInZone.Invoke(!(collision.TryGetComponent(out Character player)));
    }
}