using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl instance;
    public static SpriteRenderer sprite;

    public float speed = 5f;
    public float jumpForce = 10f;

    public float xMargin;

    [SerializeField] bool groundCheck = false;
    Rigidbody2D rd;

    [SerializeField] Sprite jumpUpSprite;
    [SerializeField] Sprite jumpDownSprite;
    [SerializeField] Sprite deadSprite;

    [SerializeField] GameObject gameOverMenu;
    bool gameOver = false;
    float gameOverHeight = 0;

    void Move()
    {
        if (Input.GetButton("Horizontal"))
        {
            rd.AddForce(speed * Input.GetAxis("Horizontal" )* Vector2.right);
            if (Input.GetAxis("Horizontal") > 0) sprite.flipX = true;
            else sprite.flipX = false;
        }
    }

    void TransverseSide()
    {
        if (transform.position.x < -1 * xMargin)
        {
            transform.position = new Vector3 (xMargin, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xMargin)
        {
            transform.position = new Vector3(xMargin * -1, transform.position.y, transform.position.z);
        }
    }

    public void Jump(float force)
    {
        rd.AddForce(new Vector2(0, force));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) { Jump(jumpForce); groundCheck = true; };
        if (collision.gameObject.CompareTag("DeadZone")) Death();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundCheck = false;
        }
    }

    public void Death()
    {
        Debug.Log("Game Over" + transform.position.y);
        sprite.sprite = deadSprite;
        gameOverHeight = transform.position.y;
        Jump(500);
        gameOver = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rd = GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    void CheckSprite()
    {
        if (rd.velocity.y > 0) sprite.sprite = jumpUpSprite;
        else sprite.sprite = jumpDownSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if (gameOverHeight - 3 > transform.position.y || groundCheck) Destroy(gameObject);
            gameOverMenu.SetActive(true);
            return;
        }
        CheckSprite();
        TransverseSide();
    }

    private void FixedUpdate()
    {
        if (gameOver) return;
        Move();
    }

    public void SetGroundCheck(bool check) { groundCheck = check; groundCheck = !check; }
}
