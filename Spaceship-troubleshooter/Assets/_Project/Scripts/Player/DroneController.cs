using Assets._Project.Scripts.Ship;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    private DroneRoot _activeDrone;
    private DroneRoot[] _drones = new DroneRoot[4];

    public void SetActiveDrone(int number)
    {
        _activeDrone = _drones[number];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
                    _activeDrone.SetCurrentObjective(targetObject.gameObject);
                }
            }
        }
    }
}
