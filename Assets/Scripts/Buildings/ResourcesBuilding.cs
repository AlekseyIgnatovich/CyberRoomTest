using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourcesBuilding : Building
{
    public bool CraftActive;// Todo
    public  bool ItemInProgress;// Todo
    public string _productionItem { get; set; }// Todo
    protected private float _startProductionTime { get; set; }

    public void StartProduction(string item)
    {
        CraftActive = true;
        _productionItem = item;
    }

    public void StopProduction()
    {
        CraftActive = false;
        ItemInProgress = false;
    }

    private void Update()
    {
        if (!CraftActive)
        {
            return;
        }

        if (!ItemInProgress)
        {
            StartProduction();
        }
        else
        {
            var settings = _gameSettings.BuildingSettings.First(b => b.Type == _buildingType);
            if (Time.time - _startProductionTime >= settings.ProductionTime)
            {
                FinishProduction();
            }
        }
    }

    protected virtual void StartProduction()
    {
        ItemInProgress = true;
        _startProductionTime = Time.time;
    }
    
    private void FinishProduction()
    {
        var settings = _gameSettings.ResourceSettings.First(r => r.Id == _productionItem);
        _data.AddGoodItem(settings.Id, 1);
        ItemInProgress = false;
    }
}
