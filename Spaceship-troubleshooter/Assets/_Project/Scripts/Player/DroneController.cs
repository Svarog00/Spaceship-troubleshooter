using Assets._Project.Scripts.Ship;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    private DroneRoot _activeDrone = null;
    private DroneRoot[] _drones = new DroneRoot[4];

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
        if(Input.GetMouseButton(0))
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
