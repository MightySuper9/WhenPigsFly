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

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !hasJumped)
        {
            Debug.Log("jumped");
            hasJumped = true;
            player.AddForce(Vector2.up * jumpforce);
        }
        if(direction == "right")
        {
            player.AddForce(Vector2.right * speed);
            spriteRenderer.flipX = false;
        }
        if (direction == "left")
        {
            player.AddForce(Vector2.left * speed);
            spriteRenderer.flipX = true;
        }
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
            Debug.Log("body collided with tilemap");
        }
    }
}
