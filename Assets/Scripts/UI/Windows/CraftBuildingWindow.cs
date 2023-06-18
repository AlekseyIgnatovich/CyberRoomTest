using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CraftBuildingWindow : UIBaseView
{
    public event Action<bool, string> OnCraftSelected;
    public event Action<string, string> OnItemsChanged;
    
    [SerializeField] private ResourceButton _resourceButtonFirst;
    [SerializeField] private ResourceButton _resourceButtonSecond;
    [SerializeField] private Image _craftItemIcon;
    [SerializeField] private StartButton _startButton;
    [SerializeField] private Button _closeButton;

    private ResourceSettings[] _resourceSettings;

    public void Init(ResourceSettings[] resourceSettings, string firstRes, string secondRes, bool inProduction)
    {
        _resourceSettings = resourceSettings;

        _closeButton.onClick.AddListener(Close);

        _startButton.Setup(inProduction);
        _startButton.OnStarted += OnStarted;

        _resourceButtonFirst.Init(resourceSettings, firstRes);
        _resourceButtonFirst.Lock(inProduction);
        _resourceButtonFirst.OnChanged += (res) =>
        {
            OnItemsChanged?.Invoke(_resourceButtonFirst.SelectedResource, _resourceButtonSecond.SelectedResource);

            UpdateCraftItem();
        };

        _resourceButtonSecond.Init(resourceSettings, secondRes);
        _resourceButtonSecond.Lock(inProduction);
        _resourceButtonSecond.OnChanged += (res) =>
        {
            OnItemsChanged?.Invoke(_resourceButtonFirst.SelectedResource, _resourceButtonSecond.SelectedResource);

            UpdateCraftItem();
        };
        
        UpdateCraftItem();
    }

    void UpdateCraftItem()
    {
        var craftItem = GetCraftItem(_resourceButtonFirst.SelectedResource, _resourceButtonSecond.SelectedResource);
        if (!string.IsNullOrEmpty(craftItem))
        {
            _craftItemIcon.sprite = _resourceSettings.First(r => r.Id == craftItem).Icon;
        }
        else
        {
            _craftItemIcon.sprite = null;
        }
    }

    string GetCraftItem(string res1, string res2)
    {
        if (res1 == res2) {
            return string.Empty;
        }

        foreach (var resource in _resourceSettings)
        {
            if (resource.CraftMaterials.Length == 0) {
                continue;
            }

            if ((resource.CraftMaterials[0].Name == res1 || resource.CraftMaterials[0].Name == res2) &&
                (resource.CraftMaterials[1].Name == res1 || resource.CraftMaterials[1].Name == res2))
            {
                return resource.Id;
            }
        }
        return string.Empty;
    }
    
    private void OnStarted(bool start)
    {
        if (string.IsNullOrEmpty(_resourceButtonFirst.SelectedResource))
        {
            _startButton.Setup(false);
            return;
        }

        var craftItem = GetCraftItem(_resourceButtonFirst.SelectedResource, _resourceButtonSecond.SelectedResource);
        if (string.IsNullOrEmpty(craftItem)) {
            _startButton.Setup(false);
            return;
        }
        
        OnCraftSelected?.Invoke(start, craftItem);
        
        _resourceButtonFirst.Lock(_startButton.State);
        _resourceButtonSecond.Lock(_startButton.State);
    }
}
