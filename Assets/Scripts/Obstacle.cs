public class Obstacle :  SpawnedItem
{
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();

        if (player)
        {
            player.Die();
        }
    }
}
