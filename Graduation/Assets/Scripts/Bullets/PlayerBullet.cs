using UnityEngine;

public class PlayerBullet : Bullet
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            Destroy(gameObject);
            enemy.TakeDamage(Damage);
        }

        if (!collision.TryGetComponent(out Player player))
        {
            Destroy(gameObject);
        }  
    }
}
