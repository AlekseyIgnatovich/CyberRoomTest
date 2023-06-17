using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Settings", order = 1)]
public class GameSettings : ScriptableObject
{
   public GuiSettings GuiSettings;
   public ResourceSettings[] ResourceSettings;
   public BuildingSettings[] BuildingSettings;
}

[Serializable]
public class GuiSettings
{
   public GameObject UIRootPrefab;

   public GameObject MainMenuWindow;//Todo типизировать
   public GameObject GameplayScreen;
   public GameObject ResourceBuildingWindow;
   public GameObject CraftBuildingWindow;
}

[Serializable]
public class ResourceSettings
{
   public string Name;
   public Sprite Icon;
   public int CraftRate;
   public ResourceType Type;

   public CraftMaterial[] CraftMaterials;
}

public enum ResourceType
{
   Material,
   CraftableItem
}

[Serializable]
public class CraftMaterial
{
   public string Name;
   public int Count;
}

[Serializable]
public class BuildingSettings
{
   public BuildingType Type;
   public float ProductionTime;
}
   
