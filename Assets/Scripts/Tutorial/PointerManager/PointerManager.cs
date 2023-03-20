using System.Collections.Generic;
using UnityEngine;

public abstract class PointerManager : MonoBehaviour
{
    [SerializeField] private List<Pointer> _pointers;

    public void EnablePointers()
    {
        for (int i = 0; i < _pointers.Count; i++)
            _pointers[i].Enable();
    }

    public void DisablePointers()
    {
        for (int i = 0; i < _pointers.Count; i++)
            _pointers[i].Disable();
    }
}
