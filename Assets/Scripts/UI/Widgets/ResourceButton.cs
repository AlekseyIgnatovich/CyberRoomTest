using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ResourceButton : MonoBehaviour
{
    public string SelectedResource
    {
        get { return _resourceSettings[_resourceIndex].Name; }
    }

    [SerializeField] private Image _icon;
    [SerializeField] private Button _button;
    [SerializeField] private ResourceType _resourceType;

    private ResourceSettings[] _resourceSettings;
    private int _resourceIndex;
    private bool _locked;
    
    void Awake()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (_locked)
        {
            return;
        }

        _resourceIndex++;
        _resourceIndex %= _resourceSettings.Length;
        
        var res = _resourceSettings[_resourceIndex];
        _icon.sprite = res.Icon;
    }


    public void Init(string selectedItem, ResourceSettings[] resourceSettings)
    {
        _resourceSettings = resourceSettings.Where(r=>r.Type == _resourceType).ToArray();
        
        if (!string.IsNullOrEmpty(selectedItem))
        {
            _resourceIndex = Array.FindIndex(_resourceSettings, (r) => r.Name == selectedItem);
            var res = _resourceSettings[_resourceIndex];
            _icon.sprite = res.Icon;
        }
    }
    
    public void Lock(bool locked)
    {
        _locked = locked;
    }
}
