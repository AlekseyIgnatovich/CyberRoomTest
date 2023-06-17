using System.Linq;
using UnityEngine;

public class MarketBuildingPresenter //Todo:копипаста
{
    private DataModel _dataModel;
    private Stock _stock;
    private ResourceSettings[] _resourceSettings;
	
    public MarketBuildingPresenter(ResourceSettings[] resourceSettings, DataModel dataModel, UIManager uiManager, Stock stock)
    {
        _resourceSettings = resourceSettings;
        _dataModel = dataModel;
        _stock = stock;
        
        var window = uiManager.ShowView<MarketBuildingWindow>();
        window.Init(resourceSettings);
        window.OnSellClicked += OnSellClicked;
    }

    private void OnSellClicked(string item)
    {
        if (_stock.GetItemsCount(item) <= 0) {
            return;
        }

        _stock.RemoveItem(item, 1);
        var settings = _resourceSettings.First(r => r.Name == item);
        _dataModel.Moneys.Value += settings.Price;
    }
}