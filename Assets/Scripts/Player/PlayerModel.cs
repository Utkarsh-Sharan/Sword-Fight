using UnityEngine;

public class PlayerModel
{
    private float moveSpeed = 5f;
    private float gravity = -20f;
    private float verticalVelocity;
    private Vector3 movementVelocity;

    public Vector3 CalculateMovement(float horizontalInput, float verticalInput, bool isGrounded)
    {
        movementVelocity.Set(horizontalInput, 0, verticalInput);
        movementVelocity.Normalize();
        movementVelocity *= moveSpeed * Time.deltaTime;

        verticalVelocity = isGrounded ? gravity * 0.3f : gravity;

        movementVelocity += verticalVelocity * Vector3.up * Time.deltaTime;

        return movementVelocity;
    }
}
