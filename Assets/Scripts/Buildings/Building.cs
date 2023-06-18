using UnityEngine;

public class Building : MonoBehaviour
{
    public enum BuildingState
    {
        Idle,
        Production,
        ItemInProgress
    }
    
    public BuildingType BuildingType => _buildingType;
    public int Id { get; private set; }

    [SerializeField] protected BuildingType _buildingType;

    protected Data _data;
    protected GameSettings _gameSettings;
    protected BuildingState _buildingState = BuildingState.Idle;

    public void Init(Data data, GameSettings gameSettings, int id)
    {
        _data = data;
        _gameSettings = gameSettings;
        Id = id;
    }
}
