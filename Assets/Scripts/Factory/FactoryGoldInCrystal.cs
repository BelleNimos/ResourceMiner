using UnityEngine;

public class FactoryGoldInCrystal : Factory
{
    private void Start()
    {
        CountResourcesRequired = FactorySettings.CountResourcesRequiredFactoryGoldInCrystal;
        CountResourceTakes = FactorySettings.CountResourcesTakesFactoryGoldInCrystal;
        SampleResource = Instantiate(PrefabContainerResource, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
    }
}
