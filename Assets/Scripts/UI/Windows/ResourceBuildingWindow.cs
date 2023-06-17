using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBuildingWindow : UIBaseView
{
    public event Action<bool, string> OnProductionStarted;
    
    [SerializeField] private ResourceButton _resourceButton;
    [SerializeField] private StartButton _startButton;
    [SerializeField] private Button _closeButton;

    private BuildingModel _buildingModel;
    
    public void Init( ResourceSettings[] resourceSettings, Building building)
    {
        _closeButton.onClick.AddListener(Close);
        
        _startButton.Init(building._inProgress);
        _startButton.OnStarted += OnStarted;
        
        _resourceButton.Init(building._productionItem, resourceSettings);
        _resourceButton.Lock(building._inProgress);
    }

    private void OnStarted(bool start)
    {
        if (string.IsNullOrEmpty(_resourceButton.SelectedResource))
        {
            _startButton.Init(false);
            return;
        }
        
        OnProductionStarted?.Invoke(start, _resourceButton.SelectedResource);
        
        
        Debug.LogError("Start: " + _resourceButton.SelectedResource);
        
    }
}
