using System.Collections.Generic;
using System;
using UnityEngine;

public class UIManager
{
    private Dictionary<Type, UIBaseView> _mediatorMap;
    private GameObject _uiRoot;

    public UIManager(GuiSettings guiSettings)
    {
        SetupRootObject(guiSettings.UIRootPrefab);
        SetupGUIMap(guiSettings);
    }

    public T ShowView <T>() where T : UIBaseView
    {
        GameObject prefab = _mediatorMap[typeof(T)].gameObject;
        var view  = GameObject.Instantiate(prefab).GetComponent<T>();
        RectTransform prefabTransform = prefab.transform as RectTransform;
        RectTransform viewTransform = view.transform as RectTransform;
        viewTransform.SetParent(_uiRoot.transform);
        viewTransform.sizeDelta = prefabTransform.sizeDelta;
        viewTransform.anchoredPosition = Vector2.zero;
        view.Show();
        
        return view;
    }

    public void CloseAll()
    {
        var views = _uiRoot.GetComponentsInChildren<UIBaseView>();
        foreach (var item in views)
        {
            item.Close();
        }
    }

    private void SetupRootObject(GameObject prefab)
    {
        _uiRoot = GameObject.Instantiate(prefab);
        GameObject.DontDestroyOnLoad(_uiRoot);
    }

    private void SetupGUIMap(GuiSettings guiSettings)
    {
        _mediatorMap = new Dictionary<Type, UIBaseView>();
        foreach (var item in guiSettings.Windows)
        {
            _mediatorMap.Add(item.GetType(), item);
        }
    }
}
