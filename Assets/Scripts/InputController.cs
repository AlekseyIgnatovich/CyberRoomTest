using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public event Action<Building> OnClickedBuilding;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
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
