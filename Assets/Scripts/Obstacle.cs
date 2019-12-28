using UnityEngine;

public class Obstacle : SpawnedItem
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player)
        {
            player.Die();
        }
    }
}
