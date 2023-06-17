using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuWindow : UIBaseView
{
    public event Action<int> OnStartClicked;
    
    [SerializeField] Toggle[] _buildingsTgls;
    [SerializeField] Button _startBtn;

    private int _buildingsCount = 1;
    
    public override void Show()
    {
        base.Show();

        for (int i = 0; i < _buildingsTgls.Length; i++)
        {
            int count = i + 1;
            _buildingsTgls[i].onValueChanged.AddListener((val) =>
            {
                if (val)
                {
                    _buildingsCount = count;
                }
            });
        }
        
        _startBtn.onClick.AddListener(() =>
        {
            OnStartClicked?.Invoke(_buildingsCount);
        });
    }
}
