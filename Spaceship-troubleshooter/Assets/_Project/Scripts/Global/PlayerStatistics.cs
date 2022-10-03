using Assets._Project.Scripts.Entities;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{
    [SerializeField] private ShipConditionController _shipCondition;
    [SerializeField] private DroneController _droneController;

    private int _problemSolvedCount;

    private void Awake()
    {
        _shipCondition.OnHealthChangedEventHandler += ShipCondition_OnHealthChangedEventHandler;
    }

    private  void OnDestroy()
    {
        _shipCondition.OnHealthChangedEventHandler -= ShipCondition_OnHealthChangedEventHandler;
    }

    private void ShipCondition_OnHealthChangedEventHandler(object sender, OnHealthChangedEventArgs e)
    {
        _problemSolvedCount++;
        if(_problemSolvedCount <= 12)
        {

        }
    }
}
