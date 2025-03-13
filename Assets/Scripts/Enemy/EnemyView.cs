using UnityEngine;
using UnityEngine.VFX;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private VisualEffect _footStepVFX;

    public void BurstFootStep() => _footStepVFX.Play();
}
