using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayScreen : UIBaseView
{
    [SerializeField] private TextMeshProUGUI _moneys;
    [SerializeField] private StockWidget _stockWidget;
    
    private DataModel _dataModel;
    
    public override void Show()
    {
        base.Show();
        ShowMoneys(0);
    }

    public void Init(DataModel dataModel, GameSettings settings, Stock stock)
    {
        _dataModel = dataModel;
        _dataModel.Moneys.OnChanged += ShowMoneys;
        
        _stockWidget.Init(settings, stock);
    }

    private void ShowMoneys(int moneys)
    {
        _moneys.text = string.Format("$: {0}", moneys);
    }
    
    public override void Close()
    {
        base.Close();
        _dataModel.Moneys.OnChanged -= ShowMoneys;
    }
}
