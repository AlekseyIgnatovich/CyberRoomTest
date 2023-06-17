using System.Linq;
using UnityEngine;

public class CraftBuilding : ResourcesBuilding
{
	public string FirstResource { get; set; }
	public string SecondResource { get; set; }
	
	protected override void StartProduction()
	{
		var settings = _gameSettings.ResourceSettings.First(r => r.Name == _productionItem);

		bool anoughMaterials = true;
		for (int i = 0; i < settings.CraftMaterials.Length; i++)
		{
			var material = settings.CraftMaterials[i];
			if (_stock.GetItemsCount(material.Name) < material.Count)
			{
				anoughMaterials = false;
			}
		}
        
		if (!anoughMaterials) {
			return;
		}
        
		for (int i = 0; i < settings.CraftMaterials.Length; i++)
		{
			var material = settings.CraftMaterials[i];
			_stock.RemoveItem(material.Name, material.Count);
		}

		ItemInProgress = true;
		_startProductionTime = Time.time;
	}
}