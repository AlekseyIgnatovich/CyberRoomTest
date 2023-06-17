using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataModel
{
    public int ResourcesBuildingsCount;

    public NotifableProperty<int> Moneys = new();

    //public List<BuildingModel> Buildings;
}

/*public class BuildingModel
{
    public int Id;
    public int SettingsName;
    public bool Production;
    public string CraftItem;
}*/