public class SpawnerLumber : Spawner
{
    private void Start()
    {
        CountPerHit = SpawnerSettings.CountPerHitLumber;
        CountResources = SpawnerSettings.CountLumber;
        DelayBeforeRecovery = SpawnerSettings.DelayBeforeRecoveryLumber;
        ProductionRate = SpawnerSettings.ProductionRateLumber;

        InstantiateResources();
    }
}
