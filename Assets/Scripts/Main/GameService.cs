using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : MonoBehaviour
{
    [Header("Player properties")]
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Animator _playerAnimator;

    private PlayerService _playerService;

    private void Start()
    {
        CreateServices();
    }

    private void CreateServices()
    {
        _playerService = new PlayerService(_playerController, _characterController, _playerAnimator);
    }
}
