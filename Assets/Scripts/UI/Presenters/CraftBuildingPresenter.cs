public class CraftBuildingPresenter
{
    private CraftBuilding _building;
	
    public CraftBuildingPresenter(ResourceSettings[] resourceSettings, UIManager uiManager, CraftBuilding building)
    {
        _building = building;
	   
        var window = uiManager.ShowView<CraftBuildingWindow>();
        window.Init(resourceSettings, building.FirstResource, building.SecondResource, building.InProduction);
        window.OnCraftSelected += OnCraftSelected;
        window.OnItemsChanged += OnItemsChanged;
    }

    private void OnItemsChanged(string res1, string res2)
    {
        _building.FirstResource = res1;
        _building.SecondResource = res2;
    }

    private void OnCraftSelected(bool start, string craftItem)
    {
        if (start)
        {
            _building.CreateItems(craftItem);
        }
        else
        {
            _building.StopCreatingItems();
        }
    }
}
