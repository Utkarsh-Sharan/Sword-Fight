using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private VisualEffect _playerFootStep;
    [SerializeField] private ParticleSystem _playerSword01;

    public void UpdateFootStep(bool state)
    {
        if(state)
            _playerFootStep.Play();
        else
            _playerFootStep.Stop();
    }

    public void PlayPlayerSword01VFX()
    {
        _playerSword01.Play();
    }
}
