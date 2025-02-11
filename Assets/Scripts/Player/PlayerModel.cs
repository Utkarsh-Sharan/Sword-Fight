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
        movementVelocity = Quaternion.Euler(0, -45f, 0) * movementVelocity;
        movementVelocity *= moveSpeed * Time.deltaTime;

        verticalVelocity = isGrounded ? gravity * 0.3f : gravity;

        movementVelocity += verticalVelocity * Vector3.up * Time.deltaTime;

        return movementVelocity;
    }

    public Quaternion GetTargetRotation()
    {
        if (movementVelocity != Vector3.zero)
        {
            float targetRotation = Quaternion.LookRotation(movementVelocity).eulerAngles.y;
            return Quaternion.Euler(0, targetRotation, 0);
        }

        return Quaternion.identity;
    }
}
