using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2;
    public Animator animator;

    [SerializeField] private float _movementSpeed = 5f;

    private Vector2 _direction;
    private bool _faceRight;

    // Start is called before the first frame update
    void Start()
    {
        //rb2 = GetComponentInParent<Rigidbody2D>();
        _faceRight = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rb2.MovePosition(rb2.position + _direction * _movementSpeed * Time.deltaTime);
    }

    public void StopMove()
    {
        _direction = Vector2.zero;
    }

    public void HandleMove(Vector2 vector, bool dash)
    {
        HandleMove(vector.x, vector.y, dash);
    }

    public void HandleMove(float x, float y, bool dash)
    {
        _direction.x = x;
        _direction.y = y;

        AnimateMove();

        if (_direction != new Vector2(0, 0))
        {
            ChangeAnimationDir();
        }
    }

    private void AnimateMove()
    {
        animator.SetFloat("Speed", _direction.sqrMagnitude);
    }

    private void ChangeAnimationDir()
    {
        _faceRight = !_faceRight;
        Vector3 Scaler = gameObject.transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
