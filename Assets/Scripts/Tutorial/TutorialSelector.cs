using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialSelector : MonoBehaviour
{
    [SerializeField] private List<Cell> _cells;
    [SerializeField] private SpawnerPointerManager _spawnerPointerManager;
    [SerializeField] private FactoryPointerManager _factoryPointerManager;
    [SerializeField] private TMP_Text _textState;

    private const string EnableText = "enable";
    private const string DisableText = "disable";

    public bool IsEnable { get; private set; }

    private void Awake()
    {
        IsEnable = true;
    }

    private void Start()
    {
        if (IsEnable == true)
            _textState.text = EnableText;
        else
            _textState.text = DisableText;
    }

    public void Switch()
    {
        if (IsEnable == false)
        {
            _spawnerPointerManager.EnablePointers();
            _textState.text = EnableText;
            IsEnable = true;

            for (int i = 0; i < _cells.Count; i++)
                _cells[i].SwitchPointers();
        }
        else
        {
            _spawnerPointerManager.DisablePointers();
            _factoryPointerManager.DisablePointers();
            _textState.text = DisableText;
            IsEnable = false;
        }
    }
}
