using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : MonoBehaviour
{
    [Header("Player properties")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private CharacterController characterController;

    private PlayerService playerService;

    private void Start()
    {
        CreateServices();
    }

    private void CreateServices()
    {
        playerService = new PlayerService(playerController, characterController);
    }
}
