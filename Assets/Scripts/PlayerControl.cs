using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Animator animating;
    public static PlayerControl instance;

    public float speed = 5f;
    public float jumpForce = 10f;

    public float xMargin; 

    [HideInInspector] public bool groundCheck = false;
    Rigidbody2D rd;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        TransverseSide();
    }

    private void FixedUpdate()
    {
        Move();
        if (groundCheck)
        {
            Jump(jumpForce);
        }
    }

    void Move()
    {
        if (Input.GetButton("Horizontal"))
        {
            rd.AddForce(speed * Input.GetAxis("Horizontal" )* Vector2.right);
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
        if (collision.gameObject.CompareTag("Ground")) groundCheck = true;
        if (collision.gameObject.CompareTag("DeadZone")) Death();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundCheck = false;
        }
    }

    void Death()
    {
        Debug.Log("Game Over");
        Destroy(gameObject);
    }
}
