using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: import UnityEngine.InputSystem and UnityEngine.SceneManagement
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    // TODO: add component references
    Rigidbody rb;
    [SerializeField] float speed = 5f;
    [SerializeField] float JumpHeight = 5f;

    Vector3 MoveValue = Vector3.zero;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move(MoveValue.x, MoveValue.y);
    }

    void OnJump()
    {
        Jump();
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, JumpHeight, rb.velocity.z);
    }

    void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        Debug.Log(direction);
        MoveValue = direction;
    }

    private void Move(float x, float z)
    {
        rb.velocity = new Vector3(x * speed, rb.velocity.y, z * speed);
    }

    private void Flatten()
    {
        transform.localScale = new Vector3(2f, 0.5f, 2f);
    }

    void OnFlatten()
    {
        Flatten();
    }
}