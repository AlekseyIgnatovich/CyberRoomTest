public class CraftBuildingController
{
    private CraftComponent _сraftComponent;
	
    public CraftBuildingController(ResourceSettings[] resourceSettings, UIManager uiManager, CraftComponent сraftComponent)
    {
        _сraftComponent = сraftComponent;
	   
        var window = uiManager.ShowView<CraftBuildingWindow>();
        window.Init(resourceSettings, _сraftComponent.FirstResource, _сraftComponent.SecondResource,
            _сraftComponent.InProduction);
        window.OnCraftSelected += OnCraftSelected;
        window.OnItemsChanged += OnItemsChanged;
    }

    private void OnItemsChanged(string res1, string res2)
    {
        _сraftComponent.FirstResource = res1;
        _сraftComponent.SecondResource = res2;
    }

    private void OnCraftSelected(bool start, string craftItem)
    {
        if (start)
        {
            _сraftComponent.CreateItems(craftItem);
        }
        else
        {
            _сraftComponent.StopCreatingItems();
        }
    }
}
