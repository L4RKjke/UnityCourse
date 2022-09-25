using UnityEngine;

public class EnemyBullet : Bullet
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Destroy(gameObject);
            player.TakeDamage(Damage);
        }

        if (!collision.TryGetComponent(out EnemyRed enemy))
        {
            Destroy(gameObject);
        }
    }
}
