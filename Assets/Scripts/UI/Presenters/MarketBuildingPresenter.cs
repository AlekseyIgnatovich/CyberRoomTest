using System.Linq;

public class MarketBuildingPresenter
{
    private Data _data;
    private ResourceSettings[] _resourceSettings;
	
    public MarketBuildingPresenter(ResourceSettings[] resourceSettings, Data data, UIManager uiManager)
    {
        _resourceSettings = resourceSettings;
        _data = data;

        var window = uiManager.ShowView<MarketBuildingWindow>();
        window.Init(resourceSettings);
        window.OnSellClicked += OnSellClicked;
    }

    private void OnSellClicked(string item)
    {
        if (_data.GetGoodsCount(item) <= 0) {
            return;
        }

        _data.RemoveGood(item, 1);
        var settings = _resourceSettings.First(r => r.Id == item);
        _data.AddMoney(settings.Price);
    }
}