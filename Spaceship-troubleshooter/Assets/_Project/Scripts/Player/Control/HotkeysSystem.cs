using Assets.Scripts.Infrastructure.Services;
using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
struct HotkeyAbility
{
    public Action OnHotkeyButtonClick;
}

public class HotkeysSystem
{
    private const string FirstModuleButtonName = "First";
    private const string SecondModuleButtonName = "Second";
    private const string ThirdModuleButtonName = "Third";
    private const string FourthModuleButtonName = "Fourth";

    private DroneController _droneController;

    private List<HotkeyAbility> _hotkeyAbilities;

    public HotkeysSystem(GameObject player)
    {
        _droneController = UnityEngine.Object.FindObjectOfType<DroneController>();

        _hotkeyAbilities = new List<HotkeyAbility>
        {
            new HotkeyAbility
            {
                OnHotkeyButtonClick = () => _droneController.SetActiveDrone(0)
            },

            new HotkeyAbility
            {
                OnHotkeyButtonClick = () => _droneController.SetActiveDrone(1)
            },

            new HotkeyAbility
            {
                OnHotkeyButtonClick = () => _droneController.SetActiveDrone(2)
            },

            new HotkeyAbility
            {
                OnHotkeyButtonClick = () => _droneController.SetActiveDrone(3)
            }
        };
    }

    public void GetInput()
    {
        if (Input.GetButtonDown(FirstModuleButtonName))
        {
            _hotkeyAbilities[0].OnHotkeyButtonClick();
        }
        if (Input.GetButtonDown(SecondModuleButtonName))
        {
            _hotkeyAbilities[1].OnHotkeyButtonClick();
        }
        if (Input.GetButtonDown(ThirdModuleButtonName))
        {
            _hotkeyAbilities[2].OnHotkeyButtonClick();
        }
        if (Input.GetButtonDown(FourthModuleButtonName))
        {
            _hotkeyAbilities[3].OnHotkeyButtonClick();
        }
    }
}

