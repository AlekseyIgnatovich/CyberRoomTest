public class ResourceBuildingController
{
	private ResourceComponent _resourceComponent;

	public ResourceBuildingController(ResourceSettings[] resourceSettings, UIManager uiManager,
		ResourceComponent resourceComponent)
	{
		_resourceComponent = resourceComponent;

		var window = uiManager.ShowView<ResourceBuildingWindow>();
		window.Init(resourceSettings, _resourceComponent.ProductionItem, _resourceComponent.InProduction);
		window.OnProductionStarted += OnProductionStarted;
	}

	private void OnProductionStarted(bool start, string craftItem)
	{
		if (start)
		{
			_resourceComponent.CreateItems(craftItem);
		}
		else
		{
			_resourceComponent.StopCreatingItems();
		}
	}
}
