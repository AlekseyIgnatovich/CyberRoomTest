using System.Linq;
using UnityEngine;

public class ResourceComponent : BaseBuildingComponent
{
    public enum BuildingState
    {
        Idle,
        Production,
        ItemInProgress
    }
    protected BuildingState _buildingState = BuildingState.Idle;
    
    public bool InProduction
    {
        get { return _buildingState == BuildingState.Production || _buildingState == BuildingState.ItemInProgress; }
    }

    public string ProductionItem { get; private set; }

    protected float _startProductionTime;

    [SerializeField] private float _productionTime;

    public void CreateItems(string item)
    {
        _buildingState = BuildingState.Production;
        ProductionItem = item;
    }

    public virtual void StopCreatingItems()
    {
        _buildingState = BuildingState.Idle;
    }

    private void Update()
    {
        if (_buildingState == BuildingState.Idle)
        {
            return;
        }

        if (_buildingState == BuildingState.Production)
        {
            StartProduction();
        }
        else
        {
            if (Time.time - _startProductionTime >= _productionTime)
            {
                FinishProduction();
            }
        }
    }

    protected virtual void StartProduction()
    {
        _buildingState = BuildingState.ItemInProgress;
        _startProductionTime = Time.time;
    }

    protected virtual void FinishProduction()
    {
        var settings = _gameSettings.ResourceSettings.First(r => r.Id == ProductionItem);
        _data.AddGoodItem(settings.Id, 1);
        _buildingState = BuildingState.Production;
    }
}
