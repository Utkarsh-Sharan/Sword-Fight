using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : GenericStateMachine<PlayerController>
{
    private Animator _playerAnimator;
    private float _movementMagnitude;

    public PlayerStateMachine(PlayerController owner) : base(owner)
    {
        this.owner = owner;
    }

    public void Initialize(Animator playerAnimator, float movementMagnitude)
    {
        _playerAnimator = playerAnimator;
        _movementMagnitude = movementMagnitude;

        CreateStates();
        SetOwner();
    }

    private void CreateStates()
    {
        states.Add(States.Idle, new IdleState<PlayerController>(this, _movementMagnitude));
        states.Add(States.Running, new RunningState<PlayerController>(this, _playerAnimator, _movementMagnitude));
    }
}
