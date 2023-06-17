using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftBuildingPresenter //Todo:копипаста
{
    private DataModel _dataModel;
    private CraftBuilding _building;
	
    public CraftBuildingPresenter(ResourceSettings[] resourceSettings, DataModel dataModel, UIManager uiManager, CraftBuilding building)
    {
        _dataModel = dataModel;
        _building = building;
	   
        var window = uiManager.ShowView<CraftBuildingWindow>();
        window.Init(resourceSettings, building);
        window.OnCraftSelected += OnCraftSelected;
    }

    private void OnCraftSelected(bool start, string craftItem)
    {
        if (start)
        {
            _building.StartProduction(craftItem);
        }
        else
        {
            _building.StopProduction();
        }
    }
}