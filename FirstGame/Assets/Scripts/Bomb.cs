using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var Player = collision.gameObject.GetComponent<Player>();

        if (Player)
        {
            Player.DestoyEntity();
            Destroy(gameObject);
        }
    }
}
