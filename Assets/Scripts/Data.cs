using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Data
{
    private const string MoneyPrefsKey = "Money";
    private const string GoodPrefsKey = "Good_";
    
    public int ResourcesBuildingsCount;

    public event Action<string, int> OnGoodChanged;
    public event Action<int> OnMoneyChanged;
    
    public int Money { get; private set; }

    private Dictionary<string, int> _goods;
    
    public Data(GameSettings gameSettings)
    {
        _goods = new Dictionary<string, int>();
        foreach (var item in gameSettings.ResourceSettings)
        {
            var value = PlayerPrefs.GetInt(GoodPrefsKey + item.Id, 0);
            _goods.Add(item.Id, value);
        }
        
        Money = PlayerPrefs.GetInt(MoneyPrefsKey, 0);
    }

    public void AddMoney(int moneys)
    {
        Money += moneys;
        OnMoneyChanged?.Invoke(Money);
    }
    
    public int GetGoodsCount(string good)
    {
        return _goods[good];
    }
    
    public void AddGoodItem(string good, int count)
    {
        _goods[good] += count;
        OnGoodChanged?.Invoke(good, _goods[good]);
    }
    
    public void RemoveGood(string good, int count)
    {
        if (_goods[good] < count)
        {
            Debug.LogError($"Can't, remove {count} {good} from {_goods[good]}");
            return;
        }
        
        _goods[good] -= count;
        OnGoodChanged?.Invoke(good, _goods[good]);
    }

    public void SaveAll()
    {
        Debug.LogError("SaveAll");
        foreach (var item in _goods)
        {
            PlayerPrefs.SetInt(GoodPrefsKey + item.Key, item.Value);
        }
        
        PlayerPrefs.SetInt(MoneyPrefsKey, Money);
    }

    public void Clear()
    {
        Money = 0;

        var keys = _goods.Keys.ToArray();
        foreach (var item in keys)
        {
            _goods[item] = 0;
        }
        PlayerPrefs.DeleteAll();
    }
}