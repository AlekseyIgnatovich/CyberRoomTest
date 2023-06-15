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
}

[Serializable]
public class GuiSettings
{
   public GameObject UIRootPrefab;

   public GameObject MainMenuWindow;//Todo типизировать
   public GameObject GameplayScreen;
   public GameObject ResourceBuildingWindow;
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
   public string Count;
}
   
