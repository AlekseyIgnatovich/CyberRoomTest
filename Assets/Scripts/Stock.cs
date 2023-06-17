using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stock
{
    public event Action<string, int> OnGoodChamnged;

    public Dictionary<string, int> Goods;

    public Stock(GameSettings gameSettings)
    {
        Goods = new Dictionary<string, int>();
        foreach (var item in gameSettings.ResourceSettings)
        {
            Goods.Add(item.Name, 0);
        }
    }
    
    public void AddStockItem(string good, int count)
    {
        Goods[good] += count;
        OnGoodChamnged?.Invoke(good, Goods[good]);
    }
    
    public void RemovetockItem(string good, int count)
    {
        Goods[good] -= count;
        OnGoodChamnged?.Invoke(good, Goods[good]);
    }
}
