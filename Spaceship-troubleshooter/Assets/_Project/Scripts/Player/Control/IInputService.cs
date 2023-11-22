using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services
{
    public interface IInputService
    {
        public Vector2 Axis { get; }

        bool IsMeleeAttackButtonDown();
        bool IsShootButtonDown();
        bool IsShootButtonReleased();

        bool IsDashButtonDown();

        bool IsHealButtonDown();
        bool IsInteractButtonDown();
        bool IsOpenInventoryButtonDown();

        bool IsAbilityButtonDown(string abilityButtonName);
    }
}
