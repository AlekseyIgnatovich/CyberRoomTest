using System.Linq;
using UnityEngine;

public class CraftComponent : ResourceComponent
{
    public string FirstResource { get; set; }
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

        bool enoughMaterials = true;
        for (int i = 0; i < settings.CraftMaterials.Length; i++)
        {
            var material = settings.CraftMaterials[i];
            if (_data.GetGoodsCount(material.Name) < material.Count)
            {
                enoughMaterials = false;
            }
        }
        
        if (!enoughMaterials) {
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
