using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StockItemWidget : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _count;
    
    public void Setup(Sprite sprite, int count)
    {
        _icon.sprite = sprite;
        _count.text = count.ToString();
    }
    
    public void Setup(int count)
    {
        _count.text = count.ToString();
    }
}
