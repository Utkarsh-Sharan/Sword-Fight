using UnityEngine;

public class PlayerService
{
    private PlayerController _playerController;

    public PlayerService(PlayerController playerController, CharacterController characterController, Animator playerAnimator, DamageApplier damageApplier)
    {
        _playerController = playerController;
        playerController.Init(characterController, playerAnimator, damageApplier);
    }

    public Transform GetPlayerTransform() => _playerController.GetPlayerTransform();
}
