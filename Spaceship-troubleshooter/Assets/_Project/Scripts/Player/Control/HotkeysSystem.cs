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

    private IInputService _inputService;
    private GameObject _player;
    private DroneController _droneController;

    private List<HotkeyAbility> _hotkeyAbilities;

    public HotkeysSystem(GameObject player)
    {
        _inputService = ServiceLocator.Container.Single<IInputService>();
        _player = player;
        _droneController = _player.GetComponent<DroneController>();

        _hotkeyAbilities = new List<HotkeyAbility>();

        _hotkeyAbilities.Add(new HotkeyAbility
        {
            OnHotkeyButtonClick = () => _droneController.SetActiveDrone(0)
        });

        _hotkeyAbilities.Add(new HotkeyAbility
        {
            OnHotkeyButtonClick = () => _droneController.SetActiveDrone(1)
        });

        _hotkeyAbilities.Add(new HotkeyAbility
        {
            OnHotkeyButtonClick = () => _droneController.SetActiveDrone(2)
        });

        _hotkeyAbilities.Add(new HotkeyAbility
        {
            OnHotkeyButtonClick = () => _droneController.SetActiveDrone(3)
        });
    }

    public void GetInput()
    {
        if (Input.GetButtonDown(FirstModuleButtonName))
        {
            _hotkeyAbilities[0].OnHotkeyButtonClick();
        }
        else if (Input.GetButtonDown(SecondModuleButtonName))
        {
            _hotkeyAbilities[1].OnHotkeyButtonClick();
        }
        else if (Input.GetButtonDown(ThirdModuleButtonName))
        {
            _hotkeyAbilities[2].OnHotkeyButtonClick();
        }
        else if (Input.GetButtonDown(FourthModuleButtonName))
        {
            _hotkeyAbilities[3].OnHotkeyButtonClick();
        }
    }
}

