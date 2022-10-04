using Assets._Project.Scripts.Entities;
using Assets._Project.Scripts.Ship;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    [SerializeField] private List<DroneRoot> _drones = new List<DroneRoot>();
    
    private DroneRoot _activeDrone;

    public void Start()
    {
        _activeDrone = _drones[0];
    }

    public void SetActiveDrone(int number)
    {
        if (_drones[number].IsAvialable)
        {
            _activeDrone = _drones[number];
        }
    }

    public void SetDroneAvialable(int number)
    {
        _drones[number].DroneModel.IsAvialable = true;
    }

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if(Input.GetMouseButton(1) && _activeDrone.IsAvialable)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] targetObjects = Physics2D.OverlapPointAll(mousePosition);
            foreach (Collider2D targetObject in targetObjects)
            {
                if (targetObject.gameObject.GetComponent<Trouble>())
                {
                    _activeDrone?.SetCurrentObjective(targetObject.gameObject);
                }
            }
        }
    }
}
