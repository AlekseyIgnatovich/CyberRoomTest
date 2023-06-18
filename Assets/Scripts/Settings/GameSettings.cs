using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Settings", order = 1)]
public class GameSettings : ScriptableObject
{
   public WinConditions WinConditions;
   public GuiSettings GuiSettings;
   public ResourceSettings[] ResourceSettings;
   public BuildingSettings[] BuildingSettings;
}

[Serializable]
public class WinConditions
{
   public int Money;
}

[Serializable]
public class GuiSettings
{
   public GameObject UIRootPrefab;

   public UIBaseView[] Windows;
}

[Serializable]
public class ResourceSettings
{
   public string Id;
   public Sprite Icon;
   public int CraftRate;
   public ResourceType Type;
   public int Price;

   public CraftMaterial[] CraftMaterials;
}

public enum ResourceType //Todo
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
   
