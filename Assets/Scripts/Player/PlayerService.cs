using UnityEngine;

public class PlayerService
{
    private PlayerController _playerController;

    public PlayerService(PlayerController playerController, CharacterController characterController, Animator playerAnimator)
    {
        _playerController = playerController;
        playerController.Init(characterController, playerAnimator);
    }

    public Transform GetPlayerTransform() => _playerController.GetPlayerTransform();
}
