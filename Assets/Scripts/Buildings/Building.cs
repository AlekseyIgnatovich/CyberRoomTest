using System.Linq;
using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildingType BuildingType => _buildingType;
    public int Id { get; private set; }

    [SerializeField] protected BuildingType _buildingType;

    protected DataModel _dataModel;
    protected Stock _stock;
    protected GameSettings _gameSettings;
    
    public void Init(DataModel dataModel, GameSettings gameSettings, int id, Stock stock)
    {
        _dataModel = dataModel;
        _gameSettings = gameSettings;
        Id = id;
        _stock = stock;
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
