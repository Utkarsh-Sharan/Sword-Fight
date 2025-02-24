using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXController : MonoBehaviour
{
    [SerializeField] private VisualEffect _playerFootStep;

    public void UpdateFootStep(bool state)
    {
        if(state)
            _playerFootStep.Play();
        else
            _playerFootStep.Stop();
    }
}
