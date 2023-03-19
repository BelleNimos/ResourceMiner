using UnityEngine;

public class FactoryCoalInLumber : Factory
{
    private void Start()
    {
        CountResourcesRequired = FactorySettings.CountResourcesRequiredFactoryCoalInLumber;
        CountResourceTakes = FactorySettings.CountResourcesTakesFactoryCoalInLumber;
        SampleResource = Instantiate(PrefabContainerResource, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
    }
}
