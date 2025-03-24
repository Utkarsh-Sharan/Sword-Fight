using UnityEngine;
using UnityEngine.VFX;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private DamageApplier _damageApplier;
    [SerializeField] private VisualEffect _playerFootStep;
    [SerializeField] private ParticleSystem _playerSword01;
    [SerializeField] private CharacterController _characterController;

    private PlayerController _playerController;

    public void SetController(PlayerController playerController) => _playerController = playerController;

    private void FixedUpdate() => _playerController?.FixedUpdatePlayer();

    private void Update() => _playerController?.UpdatePlayer();

    public void UpdateFootStep(bool state)
    {
        if(state)
            _playerFootStep.Play();
        else
            _playerFootStep.Stop();
    }

    #region Animation Events
    public void PlayPlayerSword01VFX() => _playerSword01.Play();
    public void PlayerAttackStart() => _damageApplier.enabled = true;
    public void PlayerAttackEnd() => _damageApplier.enabled = false;
    #endregion
}
