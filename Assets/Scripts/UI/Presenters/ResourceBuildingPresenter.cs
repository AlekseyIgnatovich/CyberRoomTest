public class ResourceBuildingPresenter
{
	private ResourcesBuilding _building;

	public ResourceBuildingPresenter(ResourceSettings[] resourceSettings, UIManager uiManager,
		ResourcesBuilding building)
	{
		_building = building;

		var window = uiManager.ShowView<ResourceBuildingWindow>();
		window.Init(resourceSettings, building.ProductionItem, building.InProduction);
		window.OnProductionStarted += OnProductionStarted;
	}

	private void OnProductionStarted(bool start, string craftItem)
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
