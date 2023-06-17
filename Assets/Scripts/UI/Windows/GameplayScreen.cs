using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayScreen : UIBaseView
{
    [SerializeField] private TextMeshProUGUI _moneys;
    [SerializeField] private StockWidget _stockWidget;
    
    private Data _data;
    
    public override void Show()
    {
        base.Show();
        ShowMoney(0);
    }

    public void Init(Data data, GameSettings settings)
    {
        _data = data;
        _data.OnMoneyChanged += ShowMoney;
        
        _stockWidget.Init(settings, _data);
    }

    private void ShowMoney(int moneys)
    {
        _moneys.text = string.Format("$: {0}", moneys);
    }
    
    public override void Close()
    {
        base.Close();
        _data.OnMoneyChanged-= ShowMoney;
    }
}
