using UnityEngine;

public class FactoryLumberInCoal : Factory
{
    private void Start()
    {
        CountResourcesRequired = FactorySettings.CountResourcesRequiredFactoryLumberInCoal;
        CountResourceTakes = FactorySettings.CountResourcesTakesFactoryLumberInCoal;
        SampleResource = Instantiate(PrefabContainerResource, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
    }
}
