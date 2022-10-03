using Assets._Project.Scripts.Entities;
using UnityEngine;

namespace Assets._Project.Scripts.Global
{
    public class PlayerPointsManager : MonoBehaviour
    {
        [SerializeField] private DroneController _droneController;

        [SerializeField] private int _troublesRequired;
        [SerializeField] private int _troublesRequiredStepRise;

        private int _newDroneNumber = 0;
        private int _problemSolvedCount;

        public void CountSolvedProblem()
        {
            _problemSolvedCount++;
            ActivateNewDrone();
        }

        private void ActivateNewDrone()
        {
            if (_problemSolvedCount == _troublesRequired)
            {
                _droneController.SetDroneAvialable(_newDroneNumber);
                _newDroneNumber++;
                _troublesRequired += _troublesRequiredStepRise;
            }
        }
    }
}