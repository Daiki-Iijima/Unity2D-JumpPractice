using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleJump : MonoBehaviour
{
    [SerializeField] private float jumpVelocity = 8;
    
    private Rigidbody2D _rb2d;
    
    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb2d.velocity = Vector2.up * jumpVelocity;
        }
    }
}
