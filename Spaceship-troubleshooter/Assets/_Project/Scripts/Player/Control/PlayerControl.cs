using Assets._Project.Scripts.Player.Weapon;
using Assets.Scripts.Infrastructure.Services;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private IWeapon weapon;

    private IInputService _inputService;
    private PlayerMovement _playerMovement;
    private HotkeysSystem _hotkeysSystem;

    private bool _canMove;

    public bool CanAttack { get; set; }

    public bool CanMove { 
        get => _canMove;
        set 
        {
            _canMove = value;
            if(value == false)
            {
                _playerMovement.StopMove();
            }
        }
    }

    private void Awake()
    {
        _inputService = ServiceLocator.Container.Single<IInputService>();
        _hotkeysSystem = new HotkeysSystem(gameObject);
    }

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();

        CanAttack = true;
        CanMove = true;
    }

    private void Update()
    {
        AbilitiesInput();
        MovementInput();
        GunAttackInput();
    }

    private void AbilitiesInput()
    {
        _hotkeysSystem.GetInput();
    }

    private void MovementInput()
    {
        if(_canMove && _inputService.Axis.sqrMagnitude > 0)
        {
            _playerMovement.HandleMove(_inputService.Axis, _inputService.IsDashButtonDown());
        }
        else
        {
            _playerMovement.StopMove();
        }
    }

    private void GunAttackInput()
    {
        if(_inputService.IsShootButtonDown() && CanAttack)
        {
            weapon.Shoot();
        }
    }
}
