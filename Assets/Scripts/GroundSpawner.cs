public class GroundSpawner : Spawner
{
    protected override void ChangeSpawnPosition() => _currentSpawnPosition += GetMinOffsetBetweenItems();
}
