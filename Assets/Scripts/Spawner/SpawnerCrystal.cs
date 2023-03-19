public class SpawnerCrystal : Spawner
{
    private void Start()
    {
        CountPerHit = SpawnerSettings.CountPerHitCrystal;
        CountResources = SpawnerSettings.CountCrystal;
        DelayBeforeRecovery = SpawnerSettings.DelayBeforeRecoveryCrystal;
        ProductionRate = SpawnerSettings.ProductionRateCrystal;

        InstantiateResources();
    }
}
