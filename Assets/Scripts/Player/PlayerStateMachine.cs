using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : GenericStateMachine<PlayerController>
{
    public PlayerStateMachine(PlayerController owner) : base(owner)
    {
        this.owner = owner;

        CreateStates();
        SetOwner();
    }

    private void CreateStates()
    {
        states.Add(PlayerStates.Idle, new PlayerIdleState<PlayerController>(this));
        states.Add(PlayerStates.Running, new PlayerRunningState<PlayerController>(this));
        states.Add(PlayerStates.AirBourne, new PlayerAirBourneState<PlayerController>(this));
        states.Add(PlayerStates.Attack, new PlayerAttackState<PlayerController>(this));
    }
}
