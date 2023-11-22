using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public event EventHandler OnTargetPositionReachedEventHandler;

    [SerializeField] private float _maxSpeed;
    private float _currentSpeed;

    private Rigidbody2D _rb2;

    private Vector2 _direction;
    private bool _canMove;
    private bool _faceRight;

    private Pathfinding _pathfinding;
    private int _currentPathIndex = 0;

    private List<Vector3> _pathVectorList = new List<Vector3>();

    public bool CanMove
    {
        get => _canMove;
        set
        {
            _canMove = value;
            if (_canMove)
            {
                _currentSpeed = _maxSpeed;
            }
            else
            {
                _currentSpeed = 0;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb2 = GetComponent<Rigidbody2D>();
        _pathfinding = Pathfinding.Instance;
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_canMove)
        {
            if (_pathVectorList != null)
            {
                Vector3 targetPosition = _pathVectorList[_currentPathIndex];
                if (Vector3.Distance(transform.position, targetPosition) <=  0.15f)
                {
                    _currentPathIndex++;
                    if (_currentPathIndex >= _pathVectorList.Count)
                    {
                        _canMove = false;
                        OnTargetPositionReachedEventHandler?.Invoke(this, EventArgs.Empty); //event to tranfere to another state
                        return;
                    }
                }

                _direction = (targetPosition - transform.position).normalized;
                SetSpriteDirection(_direction);
                _rb2.MovePosition(_rb2.position + _direction * _maxSpeed * Time.deltaTime); //movement
            }
        }

    }

    public void SetTargetPosition(Vector3 targetPostion)
    {
        _currentPathIndex = 0;
        _pathVectorList = _pathfinding.FindPath(transform.position, targetPostion);
    }

    public void SetSpriteDirection(Vector2 direction)
    {
        _direction = direction;
        if (_direction.x > 0 && _faceRight == true)
        {
            Flip();
        }
        if (_direction.x < 0 && _faceRight == false)
        {
            Flip();
        }
    }

    private void Flip() //turn left or right depends on player position
    {
        _faceRight = !_faceRight;
        Vector3 Scaler = gameObject.transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
