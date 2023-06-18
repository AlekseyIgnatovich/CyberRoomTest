using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Settings", order = 1)]
public class GameSettings : ScriptableObject
{
   public WinConditions WinConditions;
   public GuiSettings GuiSettings;
   public ResourceSettings[] ResourceSettings;
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
   public ResourceType Type;
   public int Price;

   public CraftMaterial[] CraftMaterials;
}

public enum ResourceType
{
   Resource,
   CraftableItem
}

[Serializable]
public class CraftMaterial
{
   public string Name;
   public int Count;
}
   
