using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WinWindowPresenter
{
    public event Action OnClose;

    public WinWindowPresenter(UIManager uiManager)
    {
        var window = uiManager.ShowView<WinWindow>();

        window.OnClosed += () => OnClose?.Invoke();
    }
}
