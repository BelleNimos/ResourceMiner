using UnityEngine;

public class FactoryIronInGold : Factory
{
    private void Start()
    {
        CountResourcesRequired = FactorySettings.CountResourcesRequiredFactoryIronInGold;
        CountResourceTakes = FactorySettings.CountResourcesTakesFactoryIronInGold;
        SampleResource = Instantiate(PrefabContainerResource, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
    }
}
