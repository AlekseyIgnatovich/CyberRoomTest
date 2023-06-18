using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildingType BuildingType => _buildingType;

    [SerializeField] protected BuildingType _buildingType;
}
