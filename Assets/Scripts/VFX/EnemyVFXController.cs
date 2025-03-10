using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyVFXController : MonoBehaviour
{
    [SerializeField] private VisualEffect _footStepVFX;

    public void Initialize(VFXScriptableObject footStepVFXSO)
    {
        _footStepVFX = footStepVFXSO.VisualEffect;
    }

    public void BurstFootStep() => _footStepVFX.Play();
}
