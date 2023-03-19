public class SpawnerCoal : Spawner
{
    private void Start()
    {
        CountPerHit = SpawnerSettings.CountPerHitCoal;
        CountResources = SpawnerSettings.CountCoal;
        DelayBeforeRecovery = SpawnerSettings.DelayBeforeRecoveryCoal;
        ProductionRate = SpawnerSettings.ProductionRateCoal;

        InstantiateResources();
    }
}
