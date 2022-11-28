using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D player;
    public Collider2D wallDetector;
    public Collider2D floorDetector;
    public string direction;
    public float speed;
    public SpriteRenderer spriteRenderer;
    public float jumpforce;
    public bool hasJumped;
    public Collider2D tilemapCollider;
    public Animator playeranimator;
    public Sprite risingSprite;
    public Sprite fallingSprite;
    public bool isTouchingTilemap;
    public bool dashandquestionmarkafter;
    public float dashforce;
    public bool isdashbuttonheld;
    public bool isdashbuttonreleased;
    public bool jumpPressed;
    void FixedUpdate()
    {
        if(isdashbuttonreleased)
        {
            if(direction == "right")
            {
                player.AddForce(Vector2.right * dashforce);
                dashandquestionmarkafter = false;
                isdashbuttonreleased = false;
            }
            else
            {
                player.AddForce(Vector2.left * dashforce);
                dashandquestionmarkafter = false;
                isdashbuttonreleased = false;
            }
        }
        if(jumpPressed && !hasJumped)
        {
            Debug.Log("jumped");
            hasJumped = true;
            player.AddForce(Vector2.up * jumpforce);
        }
        if(direction == "right" && !isdashbuttonheld)
        {
            player.AddForce(Vector2.right * speed);
            spriteRenderer.flipX = false;
        }
        if (direction == "left" && !isdashbuttonheld)
        {
            player.AddForce(Vector2.left * speed);
            spriteRenderer.flipX = true;
        }
        if (isTouchingTilemap == false || isdashbuttonheld)
        {
            playeranimator.enabled = false;
            if (player.velocity.y > 0)
            {
                spriteRenderer.sprite = risingSprite;
            }
            else
            {
                spriteRenderer.sprite = fallingSprite;
            }
        }
        else
        {
            playeranimator.enabled = true;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            isdashbuttonheld = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.Mouse1))
        {
            isdashbuttonheld = false;
            isdashbuttonreleased = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(jumpthingy());
        }

    }
    IEnumerator jumpthingy()
    {
        jumpPressed = true;
        yield return new WaitForSeconds(0.05f);
        jumpPressed = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collided");
        if (other.tag == "tilemap")
        {
            Debug.Log("collided with tilemap");
            if (direction == "right")
            {
                direction = "left";
                Debug.Log("turning left");
            }
            else if (direction == "left")
            {
                direction = "right";
                Debug.Log("turning right");
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "tilemap")
        {
            hasJumped = false;
            isTouchingTilemap = true;
            Debug.Log("body collided with tilemap");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "tilemap")
        {
            isTouchingTilemap = false;
        }
    }
}
