using System;

public class WinWindowController
{
    public event Action OnClose;

    public WinWindowController(UIManager uiManager)
    {
        var window = uiManager.ShowView<WinWindow>();

        window.OnClosed += () => OnClose?.Invoke();
    }
}
