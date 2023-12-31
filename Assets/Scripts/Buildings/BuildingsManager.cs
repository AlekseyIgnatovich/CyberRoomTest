using UnityEngine;

public class BuildingsManager : MonoBehaviour
{
	[SerializeField] private Building[] _buildings;
	
	public void Init(Data data, GameSettings gameSettings)
	{
		int resCount = 0;
		for (int i = 0; i < _buildings.Length; i++)
		{
			if (_buildings[i].BuildingType == BuildingType.Resources)
			{
				_buildings[i].gameObject.SetActive(resCount < data.ResourcesBuildingsCount);
				resCount++;
			}
		}

		var components = GetComponentsInChildren<BaseBuildingComponent>();
		foreach (var item in components)
		{
			item.Init(data, gameSettings);
		}
	}
}
