using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayScreen : UIBaseView
{
    [SerializeField] private TextMeshProUGUI _moneys;
    
    private DataModel _dataModel;
    
    public override void Show()
    {
        base.Show();
        ShowMoneys(0);
    }

    public override void Close()
    {
        base.Close();
        _dataModel.Moneys.OnChanged -= ShowMoneys;
    }

    public void Init(DataModel dataModel)
    {
        _dataModel = dataModel;
        _dataModel.Moneys.OnChanged += ShowMoneys;
    }

    private void ShowMoneys(int moneys)
    {
        _moneys.text = string.Format("$: {0}", moneys);
    }
}
