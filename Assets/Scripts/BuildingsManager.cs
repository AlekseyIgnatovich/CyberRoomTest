using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingsManager : MonoBehaviour
{
	[SerializeField] private Building[] _buildings;
	
	/*private GameSettings _gameSettings;
	private DataModel _dataModel;
	private Stock _stock;*/
	
	public void Init(GameSettings gameSettings, DataModel dataModel, Stock stock)
	{
		/*_gameSettings = gameSettings;
		_dataModel = dataModel;
		_stock = stock;*/
		
		int resCount = 0;
		for (int i = 0; i < _buildings.Length; i++)
		{
			_buildings[i].Init(dataModel, gameSettings, i, stock);
			if (_buildings[i].BuildingType == BuildingType.Resources)
			{
				_buildings[i].gameObject.SetActive(resCount < dataModel.ResourcesBuildingsCount);
				resCount++;
			}
		}
	}
}
