using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleJump : MonoBehaviour
{
    [SerializeField] private float jumpVelocity = 8;
    [SerializeField] private float jumpFallMultiplier = 1.5f;
    [SerializeField] private float moveSpeed = 1.5f;
    
    private Rigidbody2D _rb2d;
    
    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //  落下中
        if (_rb2d.velocity.y < 0)
        {
            _rb2d.gravityScale = jumpFallMultiplier;
        }
        else
        {
            //  上昇中
            _rb2d.gravityScale = 1f;
        }
        
        //  左右移動
        if (Input.GetKey(KeyCode.A))
        {
            _rb2d.velocity = new Vector2(-moveSpeed, _rb2d.velocity.y);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            _rb2d.velocity = new Vector2(moveSpeed, _rb2d.velocity.y);
        }
        
        bool isJumping = Mathf.Abs(_rb2d.velocity.y) > 0.01f;
        
        if (isJumping)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb2d.velocity = Vector2.up * jumpVelocity;
        }
    }
}
