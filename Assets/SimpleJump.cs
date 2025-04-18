using System;
using Unity.VisualScripting;
using UnityEngine;

public class SimpleJump : MonoBehaviour
{
    [SerializeField] private float jumpVelocity = 8f;
    [SerializeField] private float jumpFallMultiplier = 1.5f;
    [SerializeField] private float moveSpeed = 1.5f;
    [SerializeField] private LayerMask groundLayer;
    
    private Rigidbody2D _rb2d;
    private BoxCollider2D _collider;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        // 落下時の重力変更
        _rb2d.gravityScale = (_rb2d.velocity.y < 0) ? jumpFallMultiplier : 1f;

        int moveDirection = 0;

    float castDistance = moveSpeed * Time.deltaTime;
        // 上下の判定を若干カット
        if (Input.GetKey(KeyCode.A) && !IsHittingWall(Vector2.left,new Vector2(castDistance, 0.1f)))
        {
            moveDirection = -1;
        }
        // 上下の判定を若干カット
        else if (Input.GetKey(KeyCode.D) && !IsHittingWall(Vector2.right,new Vector2(castDistance, 0.1f)))
        {
            moveDirection = 1;
        }

        _rb2d.velocity = new Vector2(moveDirection * moveSpeed, _rb2d.velocity.y);

        bool isJumping = Mathf.Abs(_rb2d.velocity.y) > 0.01f;

        if (!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            _rb2d.velocity = Vector2.up * jumpVelocity;
        }
    }

bool IsHittingWall(Vector2 direction,Vector2 offsetSize)
{
    // 移動先のボックス中心位置を算出
    float castDistance = moveSpeed * Time.deltaTime;
    Vector2 size = _collider.size - offsetSize; 
    Vector2 origin = (Vector2)transform.position + _collider.offset;
    Vector2 castCenter = origin + direction * castDistance;
    
    // 指定領域に壁があるかチェック
    Collider2D hit = Physics2D.OverlapBox(castCenter, size, 0f, groundLayer);
    return hit != null;
}

    private void OnGUI()
    {
        if (!Application.isPlaying) return;
        
    float castDistance = moveSpeed * Time.deltaTime;
        bool isHittingRightWall = IsHittingWall(Vector2.right,new Vector2(castDistance, 0.1f));
        bool isHittingLeftWall = IsHittingWall(Vector2.left, new Vector2(castDistance, 0.1f));
        
        GUI.Label(new Rect(10, 10, 300, 30), $"right: {isHittingRightWall}");
        GUI.Label(new Rect(10, 30, 300, 30), $"left: {isHittingLeftWall}");
    }
}
