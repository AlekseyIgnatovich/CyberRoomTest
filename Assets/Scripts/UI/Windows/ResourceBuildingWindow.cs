using System;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBuildingWindow : UIBaseView
{
    public event Action<bool, string> OnProductionStarted;

    [SerializeField] private ResourceButton _resourceButton;
    [SerializeField] private StartButton _startButton;
    [SerializeField] private Button _closeButton;

    public void Init(ResourceSettings[] resourceSettings, string productionItem, bool inProduction)
    {
        _closeButton.onClick.AddListener(Close);

        _startButton.Setup(inProduction);
        _startButton.OnStarted += OnStarted;

        _resourceButton.Init(resourceSettings, productionItem);
        _resourceButton.Lock(inProduction);
    }

    private void OnStarted(bool start)
    {
        if (string.IsNullOrEmpty(_resourceButton.SelectedResource))
        {
            _startButton.Setup(false);
            return;
        }

        OnProductionStarted?.Invoke(start, _resourceButton.SelectedResource);
        _resourceButton.Lock(start);
    }
}
