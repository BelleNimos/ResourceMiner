public class SpawnerGold : Spawner
{
    private void Start()
    {
        CountPerHit = SpawnerSettings.CountPerHitGold;
        CountResources = SpawnerSettings.CountGold;
        DelayBeforeRecovery = SpawnerSettings.DelayBeforeRecoveryGold;
        ProductionRate = SpawnerSettings.ProductionRateGold;

        InstantiateResources();
    }
}
