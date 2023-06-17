using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourcesBuilding : Building
{
    private bool _enabled;
    public  bool _inProgress;// Todo
    public string _productionItem { get; set; }// Todo
    protected private float _startProductionTime { get; set; }

    public void StartProduction(string item)
    {
        _enabled = true;
        _productionItem = item;
    }

    public void StopProduction()
    {
        _enabled = false;
        _inProgress = false;
    }

    private void Update()
    {
        if (!_enabled)
        {
            return;
        }

        if (!_inProgress)
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
        _inProgress = true;
        _startProductionTime = Time.time;
    }
    
    private void FinishProduction()
    {
        var settings = _gameSettings.ResourceSettings.First(r => r.Name == _productionItem);
        _stock.AddStockItem(settings.Name, 1);
        _inProgress = false;
    }
}
