public class SpawnerIron : Spawner
{
    private void Start()
    {
        CountPerHit = SpawnerSettings.CountPerHitIron;
        CountResources = SpawnerSettings.CountIron;
        DelayBeforeRecovery = SpawnerSettings.DelayBeforeRecoveryIron;
        ProductionRate = SpawnerSettings.ProductionRateIron;

        InstantiateResources();
    }
}
