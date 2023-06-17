using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MarketBuildingWindow : UIBaseView
{
    public event Action<string> OnSellClicked;

    [SerializeField] private ResourceButton _resourceButton;
    [SerializeField] private Button _sellButton;
    [SerializeField] private Button _closeButton; //Todo: to base class 
    [SerializeField] private TextMeshProUGUI _price;

    private ResourceSettings[] _resourceSettings;

    public void Init(ResourceSettings[] resourceSettings)
    {
        _resourceSettings = resourceSettings;

        _closeButton.onClick.AddListener(Close);
        _sellButton.onClick.AddListener(SellClicked);

        _resourceButton.Init(resourceSettings, string.Empty);
        _resourceButton.OnChanged += (r) => { UpdatePrice(); };

        UpdatePrice();
    }

    private void SellClicked()
    {
        OnSellClicked?.Invoke(_resourceButton.SelectedResource);
    }

    private void UpdatePrice()
    {
        if (string.IsNullOrEmpty(_resourceButton.SelectedResource))
        {
            _price.text = "0";
            return;
        }

        _price.text = _resourceSettings.First(r => r.Id == _resourceButton.SelectedResource).Price.ToString();
    }
}