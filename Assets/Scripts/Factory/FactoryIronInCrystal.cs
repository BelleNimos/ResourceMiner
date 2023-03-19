using UnityEngine;

public class FactoryIronInCrystal : Factory
{
    private void Start()
    {
        CountResourcesRequired = FactorySettings.CountResourcesRequiredFactoryIronInCrystal;
        CountResourceTakes = FactorySettings.CountResourcesTakesFactoryIronInCrystal;
        SampleResource = Instantiate(PrefabContainerResource, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
    }
}
