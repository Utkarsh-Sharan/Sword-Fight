using UnityEngine;

public class PlayerService
{
    public PlayerService(PlayerController playerController, CharacterController characterController)
    {
        playerController.Init(characterController);
    }
}
