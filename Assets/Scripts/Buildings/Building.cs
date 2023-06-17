using System.Linq;
using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildingType BuildingType => _buildingType;
    public int Id { get; private set; }

    [SerializeField] protected BuildingType _buildingType;

    protected Data _data;
    protected GameSettings _gameSettings;
    
    public void Init(Data data, GameSettings gameSettings, int id)
    {
        this._data = data;
        _gameSettings = gameSettings;
        Id = id;
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
