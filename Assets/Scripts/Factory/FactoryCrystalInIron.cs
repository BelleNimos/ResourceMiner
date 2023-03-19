using UnityEngine;

public class FactoryCrystalInIron : Factory
{
    private void Start()
    {
        CountResourcesRequired = FactorySettings.CountResourcesRequiredFactoryCrystalInIron;
        CountResourceTakes = FactorySettings.CountResourcesTakesFactoryCrystalInIron;
        SampleResource = Instantiate(PrefabContainerResource, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
    }
}
