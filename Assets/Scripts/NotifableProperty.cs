using System;

public class NotifableProperty<T>
{
    public event Action<T> OnChanged;

    public T Value
    {
        get { return _value;}
        set
        {
            _value = value;
            OnChanged?.Invoke(_value);
        }
    }

    private T _value;
}