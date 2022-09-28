using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected Rigidbody2D body;
    [SerializeField] private float speed; // Use [SerializeField] to make variables visible and editable in the Unity inspector.
    private bool isTouchingGround = false;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isTouchingGround = true;
        }
    }

    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isTouchingGround = false;
        }
    }

    // Runs when the game starts.
    protected virtual void Awake()
    {
        // Assigns the Rigidbody2D component to the body variable.
        // Since this script is attached to the player, the Rigidbody2D
        // component is the one attached to the player.
        body = GetComponent<Rigidbody2D>();
    }

    // Runs once per frame.
    protected virtual void Update()
    {
        // Gets the horizontal and axis value. This is a value between
        // -1 and 1 (indicating left or right movement).
        float horizontal = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontal * speed, body.velocity.y); // Since y is not changed, we use the current y velocity.

        // Jumps if the player presses the space bar.
        if (Input.GetKeyDown(KeyCode.Space) && isTouchingGround)
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }
    }
}
