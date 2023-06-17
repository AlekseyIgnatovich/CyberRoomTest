using System.Linq;
using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildingType BuildingType => _buildingType;
    public int Id { get; private set; }

    [SerializeField] private BuildingType _buildingType;

    private DataModel _dataModel;
    private Stock _stock;
    private GameSettings _gameSettings;

    private bool _enabled;
    public  bool _inProgress;
    public string _productionItem;
    private float _startProductionTime;

    public void Init(DataModel dataModel, GameSettings gameSettings, int id, Stock stock)
    {
        _dataModel = dataModel;
        _gameSettings = gameSettings;
        Id = id;
        _stock = stock;
    }

    public void StartProduction(string item)
    {
        _enabled = true;
        _productionItem = item;
    }

    public void StopProduction()
    {
        _enabled = false;
    }

    private void Update()
    {
        if (!_enabled)
        {
            return;
        }

        if (!_inProgress)
        {
            StartProduction();
        }

        var settings = _gameSettings.BuildingSettings.First(b => b.Type == _buildingType);
        if (Time.time - _startProductionTime >= settings.ProductionTime)
        {
            FinishProduction();
        }
    }

    private void FinishProduction()
    {
        var settings = _gameSettings.ResourceSettings.First(r => r.Name == _productionItem);
        _stock.AddStockItem(settings.Name, 1);
        _inProgress = false;
    }

    void StartProduction()
    {
        var settings = _gameSettings.ResourceSettings.First(r => r.Name == _productionItem);

        bool anoughMaterials = true;
        for (int i = 0; i < settings.CraftMaterials.Length; i++)
        {
            var material = settings.CraftMaterials[i];
            if (_stock.Goods[material.Name] < material.Count)
            {
                anoughMaterials = false;
            }
        }
        
        if (!anoughMaterials) {
            return;
        }
        
        for (int i = 0; i < settings.CraftMaterials.Length; i++)
        {
            var material = settings.CraftMaterials[i];
            _stock.RemovetockItem(material.Name, material.Count);

        }

        _inProgress = true;
        _startProductionTime = Time.time;
    }

    class DisabledState :ProductionState
    {
        public DisabledState(Building building) : base(building)
        {
        }
    }
    
    class ProductionState
    {
        protected Building _building;
        public ProductionState(Building building)
        {
            _building = building;
        }
        
        public void Enter() { }

        public void Exit() { }
    }
}
