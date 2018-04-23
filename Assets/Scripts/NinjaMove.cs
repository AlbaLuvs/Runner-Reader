using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NinjaMove : MonoBehaviour {

    public float speed = 5;

    Rigidbody2D NinjaRB;
    public Transform XTarget;
    public GameObject restartButton, blackBackground;
    float jumpOrigin;
    int points;
    public bool inGround, endGame;

    public float advanceSpeed = 0.12f;

    public Text playerState, playerPX, playerPY, playerPoints;

    Animator playerAnim;

    void Awake()
    {
        NinjaRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponentInChildren<Animator>();

        if (PlayerPrefs.GetInt("BlackBack") > 0)
        {
            blackBackground.SetActive(false);
        }
    }

    void Update()
    {   
        if (!endGame)
        {
            if (transform.position.x != XTarget.position.x)
            {
                Vector2 XPosLevel = new Vector2(XTarget.position.x, transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, XPosLevel, speed);
            }

            if (Input.GetButtonDown("Horizontal"))
            {
                XTarget.position = new Vector2(Input.GetAxisRaw("Horizontal") * 3, 0);
                //playerAnim.SetTrigger("goFast");
            }
            if (Input.GetButtonUp("Horizontal"))
            {
                //playerAnim.SetTrigger("goSlow");
                XTarget.position = new Vector2(0, 0);
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (inGround)
                {
                    jumpOrigin = transform.position.y;
                    NinjaRB.AddForce(Vector2.up * 8, ForceMode2D.Impulse);
                    advanceSpeed += 0.001f;
                    playerAnim.SetTrigger("Jump");
                    inGround = false;
                }
            }

            if (!inGround)
            {
                if (Input.GetButton("Jump"))
                {
                    if (transform.position.y < (jumpOrigin + 3))
                    {
                        NinjaRB.AddForce(Vector2.up * 8, ForceMode2D.Force);
                    }
                }
            }

            playerPX.text = "Player X position: " + transform.position.x;
            playerPY.text = "Player Y position: " + transform.position.y;
            if (inGround)
            {
                playerState.text = "Current State: Running";
                playerAnim.SetTrigger("Run");
            } else
            {
                if (NinjaRB.velocity.y < 0)
                {
                    if (Input.GetButton("Jump"))
                    {
                        playerState.text = "Current State: Gliding";
                        playerAnim.SetTrigger("Glide");
                    }
                    else
                    {
                        playerState.text = "Current State: Falling";
                        playerAnim.SetTrigger("Jump");
                    }

                } else
                {
                    playerState.text = "Current State: Jumping";
                    playerAnim.SetTrigger("Jump");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "EndGame":
                if (!endGame)
                {
                    restartButton.SetActive(true);
                    //trigger fall ninja anim
                    NinjaRB.velocity = Vector2.zero;
                    NinjaRB.AddForce(Vector2.up * 7, ForceMode2D.Impulse);
                    endGame = true;
                    playerState.text = "Current State: Rebooting";
                    playerAnim.SetTrigger("Reboot");
                }
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case "Ground":
                if (!inGround)
                {
                    inGround = true;
                }
                break;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case "Ground":
                if (Input.GetAxisRaw("Vertical") < 0)
                {
                    inGround = false;
                    collision.collider.isTrigger = true;
                }
                points += 1;
                playerPoints.text = "Points: " + points.ToString("#,###,##0");
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case "Ground":
                if (inGround)
                {
                    inGround = false;
                }
                break;
        }
    }

    public void RestartLevel(bool visual)
    {
        if (visual)
        {
            PlayerPrefs.SetInt("BlackBack", 1);
        } else
        {
            PlayerPrefs.SetInt("BlackBack", 0);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
