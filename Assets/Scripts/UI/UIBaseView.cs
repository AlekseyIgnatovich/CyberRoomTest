using UnityEngine;

public abstract class UIBaseView : MonoBehaviour
{
    public virtual void Show()
    {
        
    }

    public virtual void Close()
    {
        GameObject.Destroy(gameObject);
    }
}
