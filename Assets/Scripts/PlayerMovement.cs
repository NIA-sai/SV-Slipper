using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    [SerializeField]
    private bool movAble = true;
    public bool MovAble { get => movAble; set => movAble = value; }
    private float moveSpeed;
    public float speed;
    SpriteRenderer sr;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        moveSpeed = speed;
    }

    private void FixedUpdate()
    {
        if (!movAble) return;
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            moveSpeed = speed * 2.5f;
        }
        else
        {
            moveSpeed = speed;
        }
        rb.velocity = moveInput * moveSpeed;
    }
    private void OnMove(InputValue move)
    {
        if (!movAble) return;
        moveInput = move.Get<Vector2>();
        sr.flipX = moveInput.x < 0 ? true : (moveInput.x > 0 ? false : sr.flipX);
    }

}
