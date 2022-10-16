using Assets._Project.Scripts.Entities;
using System;
using UnityEngine;

namespace Assets._Project.Scripts.Global
{
    public class PlayerPointsManager : MonoBehaviour
    {
        public event EventHandler OnPointsAdded;

        [SerializeField] private DroneController _droneController;

        [SerializeField] private int _troublesRequired;
        [SerializeField] private int _troublesRequiredStepRise;

        private int _newDroneNumber = 0;
        private int _problemSolvedCount;

        public void CountSolvedProblem()
        {
            _problemSolvedCount++;
            ActivateNewDrone();

            OnPointsAdded?.Invoke(this, EventArgs.Empty);
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