using UnityEngine;

public class FactoryCrystalInGold : Factory
{
    private void Start()
    {
        CountResourcesRequired = FactorySettings.CountResourcesRequiredFactoryCrystalInGold;
        CountResourceTakes = FactorySettings.CountResourcesTakesFactoryCrystalInGold;
        SampleResource = Instantiate(PrefabContainerResource, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
    }
}
