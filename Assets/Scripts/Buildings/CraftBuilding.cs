using System.Linq;
using UnityEngine;

public class CraftBuilding : ResourcesBuilding
{
	public string FirstResource { get; set; } //Todo
	public string SecondResource { get; set; }

	public override void StopCreatingItems()
	{
		_buildingState = BuildingState.Idle;

		var settings = _gameSettings.ResourceSettings.First(r => r.Id == ProductionItem);
		for (int i = 0; i < settings.CraftMaterials.Length; i++)
		{
			var material = settings.CraftMaterials[i];
			_data.AddGoodItem(material.Name, material.Count);
		}
	}

	protected override void StartProduction()
	{
		var settings = _gameSettings.ResourceSettings.First(r => r.Id == ProductionItem);

		bool anoughMaterials = true;
		for (int i = 0; i < settings.CraftMaterials.Length; i++)
		{
			var material = settings.CraftMaterials[i];
			if (_data.GetGoodsCount(material.Name) < material.Count)
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
			_data.RemoveGood(material.Name, material.Count);
		}

		_buildingState = BuildingState.ItemInProgress;
		_startProductionTime = Time.time;
	}
}
