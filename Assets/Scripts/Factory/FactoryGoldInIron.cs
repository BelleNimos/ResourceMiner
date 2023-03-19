using UnityEngine;

public class FactoryGoldInIron : Factory
{
    private void Start()
    {
        CountResourcesRequired = FactorySettings.CountResourcesRequiredFactoryGoldInIron;
        CountResourceTakes = FactorySettings.CountResourcesTakesFactoryGoldInIron;
        SampleResource = Instantiate(PrefabContainerResource, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
    }
}
