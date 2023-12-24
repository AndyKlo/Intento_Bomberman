using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public new Rigidbody2D rb { get; private set; }
    private Vector2 direction = Vector2.down;
    public float speed = 5f;

    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;

    public AnimatedSpriteRender spriteUp;
    public AnimatedSpriteRender spriteDown;
    public AnimatedSpriteRender spriteLeft;
    public AnimatedSpriteRender spriteRight;
    private AnimatedSpriteRender currentSprite;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSprite = spriteDown;
    }

    private void Update()
    {
        if(Input.GetKey(upKey))
        {
            SetSpriteDirection(Vector2.up, spriteUp);
        }
        else if (Input.GetKey(downKey))
        {
            SetSpriteDirection(Vector2.down, spriteDown);
        }
        else if (Input.GetKey(leftKey))
        {
            SetSpriteDirection(Vector2.left, spriteLeft);
        }
        else if (Input.GetKey(rightKey))
        {
            SetSpriteDirection(Vector2.right, spriteRight);
        }
        else
        {
            SetSpriteDirection(Vector2.zero, currentSprite);
        }
    }
    private void FixedUpdate()
    {
        Vector2 Position = rb.position;
        Vector2 Translation = direction * speed * Time.fixedDeltaTime;

        rb.MovePosition(Position + Translation);
    }

    private void SetSpriteDirection(Vector2 dir, AnimatedSpriteRender sprite)
    {
        direction = dir;
        spriteUp.enabled = sprite == spriteUp;
        spriteDown.enabled = sprite == spriteDown;
        spriteLeft.enabled = sprite == spriteLeft;
        spriteRight.enabled = sprite == spriteRight;

        currentSprite = sprite;
        currentSprite.idle = dir == Vector2.zero;
    }
}
