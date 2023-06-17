using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CraftBuildingWindow : UIBaseView
{
    public event Action<bool, string> OnCraftSelected;
    
    [SerializeField] private ResourceButton _resourceButtonFirst;
    [SerializeField] private ResourceButton _resourceButtonSecond;
    [SerializeField] private Image _craftItemIcon;
    [SerializeField] private StartButton _startButton;
    [SerializeField] private Button _closeButton;

    private ResourceSettings[] _resourceSettings;
    private CraftBuilding _building;

    public void Init(ResourceSettings[] resourceSettings, CraftBuilding building)
    {
        _resourceSettings = resourceSettings;
        _building = building;
        
        _closeButton.onClick.AddListener(Close);

        _startButton.Init(building.CraftActive);
        _startButton.OnStarted += OnStarted;

        _resourceButtonFirst.Init(resourceSettings, building.FirstResource);
        _resourceButtonFirst.Lock(building.CraftActive);
        _resourceButtonFirst.OnChanged += (res) =>
        {
            building.FirstResource = res;

            UpdateCraftItem();
        };

        _resourceButtonSecond.Init(resourceSettings, building.SecondResource);
        _resourceButtonSecond.Lock(building.CraftActive);
        _resourceButtonSecond.OnChanged += (res) =>
        {
            building.SecondResource = res;
            UpdateCraftItem();
        };
        
        UpdateCraftItem();
    }

    void UpdateCraftItem()
    {
        var craftItem = GetCraftItem(_building.FirstResource, _building.SecondResource);
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
            _startButton.Init(false);
            return;
        }

        OnCraftSelected?.Invoke(start, GetCraftItem(_building.FirstResource, _building.SecondResource));
        
        _resourceButtonFirst.Lock(_building.CraftActive);
        _resourceButtonSecond.Lock(_building.CraftActive);
    }
}
