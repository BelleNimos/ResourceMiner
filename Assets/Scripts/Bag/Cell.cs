using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cell : MonoBehaviour
{
    [SerializeField] private ResourceUI _resourceUI;
    [SerializeField] private Resource _prefabResource;
    [SerializeField] private string _name;

    private Stack<Resource> _resources;

    public string Name => _name;
    public int MaxCountResources { get; private set; }
    public int CurrentCountResources => _resources.Count;

    private void Awake()
    {
        _resources = new Stack<Resource>();
    }

    private void SetFlagResourceUI()
    {
        if (CurrentCountResources == 0)
            _resourceUI.ChangePosition(true);
        else
            _resourceUI.ChangePosition(false);
    }

    public void AssignCount()
    {
        _resourceUI.SetMaxCount(MaxCountResources);
        _resourceUI.SetCurrentCount(CurrentCountResources, false);
        SetFlagResourceUI();
    }

    public void AddResource(Resource resource)
    {
        _resources.Push(resource);
        _resourceUI.SetCurrentCount(CurrentCountResources, true);
        SetFlagResourceUI();
    }

    public void PullResource(ref Resource resource)
    {
        resource = _resources.Pop();
        _resourceUI.SetCurrentCount(CurrentCountResources, false);
        SetFlagResourceUI();
    }

    public void InstantiateResources(int count, Transform transform)
    {
        for (int i = 0; i < count; i++)
        {
            Resource resource = Instantiate(_prefabResource, transform);
            resource.transform.DOScale(new Vector3( 0, 0, 0), 0.1f);
            _resources.Push(resource);
        }
    }

    public void SetMaxCountResources(int count)
    {
        MaxCountResources = count;
    }
}
