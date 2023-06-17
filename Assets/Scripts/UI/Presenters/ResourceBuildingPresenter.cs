using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBuildingPresenter
{
	private DataModel _dataModel;
	private Building _building;
	
   public ResourceBuildingPresenter(ResourceSettings[] resourceSettings, DataModel dataModel, UIManager uiManager, Building building)
   {
	   _dataModel = dataModel;
	   _building = building;
	   
	   var window = uiManager.ShowView<ResourceBuildingWindow>();
	   window.Init(resourceSettings, building);
	   window.OnProductionStarted += OnProductionStarted;
   }

   private void OnProductionStarted(bool start, string craftItem)
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
