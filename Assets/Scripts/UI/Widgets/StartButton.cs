using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartButton : MonoBehaviour
{
    public event Action<bool> OnStarted;

    public bool State => _state;
    
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private bool _changeState = true;

    private bool _state;
    
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ChangeState);
    }

    private void ChangeState()
    {
        if (_changeState) {
            _state = !_state;
        }

        SetupState(_state);
        OnStarted?.Invoke(_state);
    }

    private void SetupState(bool state)
    {
        _state = state;
        _text.text = _state ? "Stop" : "Start";
    }

    public void Setup(bool state)
    {
        SetupState(state);
    }
}
