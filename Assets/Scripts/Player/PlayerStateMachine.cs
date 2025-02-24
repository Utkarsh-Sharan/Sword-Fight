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
        states.Add(States.Idle, new IdleState<PlayerController>(this));
    }
}
