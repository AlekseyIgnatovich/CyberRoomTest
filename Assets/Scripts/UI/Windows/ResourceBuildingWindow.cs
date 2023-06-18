using System;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBuildingWindow : UIBaseView
{
    public event Action<bool, string> OnProductionStarted;

    [SerializeField] private ResourceButton _resourceButton;
    [SerializeField] private StartButton _startButton;
    [SerializeField] private Button _closeButton;

    public void Init(ResourceSettings[] resourceSettings, ResourcesBuilding building)
    {
        _closeButton.onClick.AddListener(Close);

        _startButton.Init(building.InProduction);
        _startButton.OnStarted += OnStarted;

        _resourceButton.Init(resourceSettings, building.ProductionItem);
        _resourceButton.Lock(building.InProduction);
    }

    private void OnStarted(bool start)
    {
        if (string.IsNullOrEmpty(_resourceButton.SelectedResource))
        {
            _startButton.Init(false);
            return;
        }

        OnProductionStarted?.Invoke(start, _resourceButton.SelectedResource);
        _resourceButton.Lock(start);
    }
}
