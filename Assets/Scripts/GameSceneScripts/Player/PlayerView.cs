using UnityEngine;
using UnityEngine.VFX;

public class PlayerView : MonoBehaviour, IDamageable
{
    [SerializeField] private DamageApplier _damageApplier;
    [SerializeField] private VisualEffect _playerFootStep;
    [SerializeField] private ParticleSystem _playerSword01;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Animator _playerAnimator;

    private PlayerController _playerController;
    private EventService _eventService;

    public void Initialize(PlayerController playerController, EventService eventService)
    {
        _playerController = playerController;
        _eventService = eventService;
    }

    private void FixedUpdate() => _playerController?.FixedUpdatePlayer();

    private void Update() => _playerController?.UpdatePlayer();

    public void UpdateFootStep(bool state)
    {
        if(state)
            _playerFootStep.Play();
        else
            _playerFootStep.Stop();
    }

    public void OnDamage() => _playerController.OnDamage();

    public void PlayerDead()
    {
        _eventService.OnPlayerDeathEvent.InvokeEvent();
        _playerAnimator.SetTrigger(ConstantStrings.DEATH_PARAMETER);
        Destroy(this);
    }

    #region Getters
    public Animator GetPlayerAnimator() => _playerAnimator;
    public CharacterController GetCharacterController() => _characterController;
    #endregion

    #region Animation Events
    public void PlayPlayerSword01VFX() => _playerSword01.Play();
    public void PlayerAttackStart() => _damageApplier.enabled = true;
    public void PlayerAttackEnd() => _damageApplier.enabled = false;
    #endregion
}
