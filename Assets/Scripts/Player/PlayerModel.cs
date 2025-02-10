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

        if (!isGrounded)
            verticalVelocity = gravity;
        else
            verticalVelocity = gravity * 0.3f;

        movementVelocity += verticalVelocity * Vector3.up * Time.deltaTime;

        return movementVelocity;
    }

    public Quaternion GetTargetRotation()
    {
        if (movementVelocity != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementVelocity);
            return Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
        }

        return Quaternion.identity;
    }
}
