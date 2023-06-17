using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ResourceButton : MonoBehaviour
{
    public event Action<string> OnChanged;

    public string SelectedResource
    {
        get { return _resourceIndex == -1 ? string.Empty : _resourceSettings[_resourceIndex].Name; }
    }

    [SerializeField] private Image _icon;
    [SerializeField] private Button _button;
    [SerializeField] private ResourceType _resourceType;

    private ResourceSettings[] _resourceSettings;
    private int _resourceIndex = -1;
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

        OnChanged?.Invoke(res.Name);
    }

    public void Init(ResourceSettings[] resourceSettings, string selectedItem)
    {
        _resourceSettings = resourceSettings.Where(r => r.Type == _resourceType).ToArray();

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
