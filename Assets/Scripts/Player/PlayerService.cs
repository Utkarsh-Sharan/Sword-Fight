using UnityEngine;

public class PlayerService
{
    public PlayerService(PlayerController playerController, CharacterController characterController, Animator playerAnimator)
    {
        playerController.Init(characterController, playerAnimator);
    }
}
