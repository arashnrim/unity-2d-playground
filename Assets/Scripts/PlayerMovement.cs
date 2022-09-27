using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed; // Use [SerializeField] to make variables visible and editable in the Unity inspector.
    private bool isTouchingGround = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isTouchingGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isTouchingGround = false;
        }
    }

    // Runs when the game starts.
    private void Awake()
    {
        // Assigns the Rigidbody2D component to the body variable.
        // Since this script is attached to the player, the Rigidbody2D
        // component is the one attached to the player.
        body = GetComponent<Rigidbody2D>();
    }

    // Runs once per frame.
    private void Update()
    {
        // Gets the horizontal and axis value. This is a value between
        // -1 and 1 (indicating left or right movement).
        float horizontal = Input.GetAxis("Horizontal");
        body.rotation = horizontal * -15; // Rotates the player based on the horizontal axis value.
        body.velocity = new Vector2(horizontal * speed, body.velocity.y); // Since y is not changed, we use the current y velocity.

        // Jumps if the player presses the space bar.
        if (Input.GetKeyDown(KeyCode.Space) && isTouchingGround)
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }
    }
}
