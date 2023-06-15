using System.Collections.Generic;
using System;
using UnityEngine;

public class UIManager
{
    //private Dictionary<Type, UIBaseView> _activeViews;
    private Dictionary<Type, GameObject> _mediatorMap;
    private GameObject _uiRoot;

    public UIManager(GuiSettings guiSettings)
    {
        SetupRootObject(guiSettings.UIRootPrefab);
        SetupGUIMap(guiSettings);
    }

    /*//ToDo
    public void HideCurrentScreen()
    {
        if (_activeViews != null)
        {
            _activeViews.Hide();
            GameObject.Destroy(_activeViews.gameObject);
        }
    }*/

    public T ShowView <T>() where T : UIBaseView
    {
        GameObject prefab = _mediatorMap[typeof(T)];
        var view  = GameObject.Instantiate(prefab).GetComponent<T>();
        RectTransform prefabTransform = prefab.transform as RectTransform;
        RectTransform viewTransform = view.transform as RectTransform;
        viewTransform.SetParent(_uiRoot.transform);
        viewTransform.sizeDelta = prefabTransform.sizeDelta;
        viewTransform.anchoredPosition = Vector2.zero;
        view.Show();
        
        //_activeViews.Add(typeof(T), view);
        return view as T;
    }

    private void SetupRootObject(GameObject prefab)
    {
        _uiRoot = GameObject.Instantiate(prefab);
        GameObject.DontDestroyOnLoad(_uiRoot);
    }

    private void SetupGUIMap(GuiSettings guiSettings)
    {
        _mediatorMap = new Dictionary<Type, GameObject>();
        _mediatorMap.Add(typeof(MainMenuWindow), guiSettings.MainMenuWindow);
        _mediatorMap.Add(typeof(GameplayScreen), guiSettings.GameplayScreen);
        _mediatorMap.Add(typeof(ResourceBuildingWindow), guiSettings.ResourceBuildingWindow);
    }
}
