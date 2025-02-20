using UnityEngine;

public class PlayerModel
{
    private float moveSpeed = 5f;
    private float gravity = -20f;
    private float verticalVelocity;
    private Vector3 movementVelocity;

    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    public Vector3 CalculateMovement(float horizontalInput, float verticalInput, bool isGrounded)
    {
        movementVelocity.Set(horizontalInput, 0, verticalInput);
        movementVelocity.Normalize();
        movementVelocity *= moveSpeed * Time.deltaTime;

        verticalVelocity = isGrounded ? gravity * 0.3f : gravity;
        movementVelocity += verticalVelocity * Vector3.up * Time.deltaTime;

        return movementVelocity;
    }

    public Quaternion CalculateRotation(Vector3 direction, float currentYRotation)
    {
        if(direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(currentYRotation, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            return Quaternion.Euler(0, angle, 0);
        }

        return Quaternion.Euler(0, currentYRotation, 0);
    }
}
