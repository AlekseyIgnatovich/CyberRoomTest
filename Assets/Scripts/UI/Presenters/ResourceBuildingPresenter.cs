using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBuildingPresenter
{
	private Data _data;
	private ResourcesBuilding _building;
	
   public ResourceBuildingPresenter(ResourceSettings[] resourceSettings, Data data, UIManager uiManager, ResourcesBuilding building)
   {
	   _data = data;
	   _building = building;
	   
	   var window = uiManager.ShowView<ResourceBuildingWindow>();
	   window.Init(resourceSettings, building);
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
		   _building.StopItemsCreating();
	   }
   }
}
