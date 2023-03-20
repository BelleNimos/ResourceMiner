using System.Collections.Generic;
using UnityEngine;

public abstract class Cell : MonoBehaviour
{
    [SerializeField] private TutorialSelector _tutorialSelector;
    [SerializeField] private List<FactoryPointer> _factoryPointers;
    [SerializeField] private ResourceUI _resourceUI;
    [SerializeField] private Resource _prefabResource;
    [SerializeField] private string _name;

    private Stack<Resource> _resources;

    public string Name => _name;
    public int CurrentCountResources => _resources.Count;
    public int MaxCountResources { get; private set; }

    private void Awake()
    {
        _resources = new Stack<Resource>();
    }

    private void Start()
    {
        SwitchPointers();
    }

    private void SetFlagResourceUI()
    {
        if (CurrentCountResources == 0)
            _resourceUI.ChangePosition(true);
        else
            _resourceUI.ChangePosition(false);
    }

    public void SwitchPointers()
    {
        if (_tutorialSelector.IsEnable == true)
        {
            if (_resources.Count == 0)
                for (int i = 0; i < _factoryPointers.Count; i++)
                    _factoryPointers[i].Disable();
            else
                for (int i = 0; i < _factoryPointers.Count; i++)
                    _factoryPointers[i].Enable();
        }
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
        SwitchPointers();
    }

    public void PullResource(ref Resource resource)
    {
        resource = _resources.Pop();
        _resourceUI.SetCurrentCount(CurrentCountResources, false);
        SetFlagResourceUI();
        SwitchPointers();
    }

    public void InstantiateResources(int count, Transform transform)
    {
        for (int i = 0; i < count; i++)
        {
            Resource resource = Instantiate(_prefabResource, transform);
            _resources.Push(resource);
            resource.PlayDecreaseAnimation();
        }
    }

    public void SetMaxCountResources(int count)
    {
        MaxCountResources = count;
    }
}
