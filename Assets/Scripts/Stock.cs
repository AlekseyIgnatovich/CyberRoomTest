using System;
using System.Collections.Generic;
using UnityEngine;

public class Stock
{
    public event Action<string, int> OnGoodChamnged;

    private Dictionary<string, int> _goods;

    public Stock(GameSettings gameSettings)
    {
        _goods = new Dictionary<string, int>();
        foreach (var item in gameSettings.ResourceSettings)
        {
            _goods.Add(item.Name, 0);
        }
    }
    
    public int GetItemsCount(string good)
    {
        return _goods[good];
    }
    
    public void AddItem(string good, int count)
    {
        _goods[good] += count;
        OnGoodChamnged?.Invoke(good, _goods[good]);
    }
    
    public void RemoveItem(string good, int count)
    {
        if (_goods[good] < count)
        {
            Debug.LogError($"Can't, remove {count} {good} from {_goods[good]}");
            return;
        }
        
        _goods[good] -= count;
        OnGoodChamnged?.Invoke(good, _goods[good]);
    }
}
