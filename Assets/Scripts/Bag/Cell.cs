using System.Collections.Generic;

public class Cell
{
    private Stack<Resource> _resources;
    private ResourceUI _resourceUI;
    public int MaxCountResources { get; private set; }
    public int CurrentCountResources => _resources.Count;

    public Cell(int count)
    {
        _resources = new Stack<Resource>();
        MaxCountResources = count;
    }

    private void SetFlagResourceUI()
    {
        if (CurrentCountResources == 0)
            _resourceUI.ChangePosition(true);
        else
            _resourceUI.ChangePosition(false);
    }

    public void SetResourceUI(ResourceUI resourceUI)
    {
        _resourceUI = resourceUI;
    }

    public void SetMaxCountResources(int count)
    {
        MaxCountResources = count;
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
}
