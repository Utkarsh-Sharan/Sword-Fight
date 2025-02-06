using UnityEngine;

public class PlayerModel
{
    private float moveSpeed = 5f;
    private float verticalVelocity;
    private float gravity = -9.8f;
    private Vector3 movementVelocity;

    public Vector3 CalculateMovement(float horizontalInput, float verticalInput)
    {
        movementVelocity.Set(horizontalInput, 0, verticalInput);
        movementVelocity.Normalize();
        movementVelocity = Quaternion.Euler(0, -45f, 0) * movementVelocity;
        movementVelocity *= moveSpeed * Time.deltaTime;

        return movementVelocity;
    }
}
