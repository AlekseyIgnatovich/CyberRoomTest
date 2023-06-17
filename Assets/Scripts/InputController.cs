using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public event Action<Building> OnClickedBuilding;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool isOverUI = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
            if (Physics.Raycast(ray, out hit, 100f) && !isOverUI)
            {
                if (hit.transform != null)
                {
                    CurrentClickedGameObject(hit.transform.gameObject);
                }
            }
        }
    }

    public void CurrentClickedGameObject(GameObject target)
    {
        if (target.CompareTag(Constants.BuildingTag))
        {
            var building = target.GetComponent<Building>();
            OnClickedBuilding?.Invoke(building);
        }
    }
}
