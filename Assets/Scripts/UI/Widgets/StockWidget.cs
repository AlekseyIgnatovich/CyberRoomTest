using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockWidget : MonoBehaviour
{
    [SerializeField] private StockItemWidget _stockItemPrefab;

    private Dictionary<string, StockItemWidget> _items = new Dictionary<string, StockItemWidget>();

    public void Init(GameSettings gameSettings, Stock stock)
    {
        foreach (var resource in gameSettings.ResourceSettings)
        {
            var item = GameObject.Instantiate(_stockItemPrefab).GetComponent<StockItemWidget>();
            item.transform.SetParent(transform);
            item.transform.localPosition = Vector3.zero;
            item.Setup(resource.Icon, 0);

            _items[resource.Name] = item;
        }

        stock.OnGoodChamnged += OnGoodChamnged;
    }

    private void OnGoodChamnged(string resource, int count)
    {
        _items[resource].Setup(count);
    }
}
