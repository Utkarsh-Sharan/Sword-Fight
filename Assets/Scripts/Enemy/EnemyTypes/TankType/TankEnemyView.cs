using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemyView : EnemyView
{
    public void BurstFootStep() => footStepVFX.Play();
    public void PlayAttackVFX() => attackVFX.Play();
}
