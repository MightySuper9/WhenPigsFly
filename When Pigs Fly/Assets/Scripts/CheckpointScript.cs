using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckpointScript : MonoBehaviour
{
    public static int playerCheckpointNum = 0;
    public int flagCheckpointNum;
    public SpriteRenderer spriteRenderer;
    public Sprite activatedSprite;
    public AnimationClip changetoActivated;
    public Animator animator;
    public static Vector2 checkPointLocation;
    public GameObject player;
    public string direction;
    public static int attempts;
    public TextMeshProUGUI text;
    public void Start()
    {
        animator.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (flagCheckpointNum > playerCheckpointNum)
            {
                checkPointLocation = this.gameObject.transform.position;
                StartCoroutine(animationPlay());
                playerCheckpointNum = flagCheckpointNum;
            }
        }
    }
    private void Update()
    {
        text.text = "Respawns: " + attempts;
        if ((Input.GetKeyDown(KeyCode.R) || PlayerKiller.isPlayerDead)&& flagCheckpointNum == playerCheckpointNum)
        {
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.GetComponent<PlayerController>().direction = direction;
            player.transform.position = checkPointLocation;
            PlayerKiller.isPlayerDead = false;
            attempts += 1;
        }
    }
    IEnumerator animationPlay()
    {
        Debug.Log("animator animated");
        animator.enabled = true;
        animator.Play(changetoActivated.name);
        yield return new WaitForSeconds(0.917f);
        animator.enabled = false;
        spriteRenderer.sprite = activatedSprite;
    }
}
