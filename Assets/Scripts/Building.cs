using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildingType BuildingType => _buildingType;
    
    [SerializeField] private BuildingType _buildingType;

}
