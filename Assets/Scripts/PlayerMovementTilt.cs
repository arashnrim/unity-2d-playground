using UnityEngine;

public class PlayerMovementTilt : PlayerMovement
{
    // Runs once per frame.
    protected override void Update()
    {
        base.Update();

        float horizontal = Input.GetAxis("Horizontal");
        body.rotation = horizontal * -15; // Rotates the player based on the horizontal axis value.
    }
}
