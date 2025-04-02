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

    public void Initialize(PlayerController playerController)
    {
        _playerController = playerController;
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

    #region Animation Events
    public void PlayPlayerSword01VFX() => _playerSword01.Play();
    public void PlayerAttackStart()
    {
        EventService.Instance.OnDamageEvent.AddListener(OnAttack);
        _damageApplier.enabled = true;
    }
    public void PlayerAttackEnd()
    {
        EventService.Instance.OnDamageEvent.RemoveListener(OnAttack);
        _damageApplier.enabled = false;
    }
    #endregion

    private int OnAttack() => _playerController.GetPlayerSO().AttackDamage;

    public void OnDamage(int damageAmount) => _playerController.OnDamage(damageAmount);

    public void PlayerDead()
    {
        EventService.Instance.OnPlayerDeathEvent.InvokeEvent();
        _playerAnimator.SetTrigger(ConstantStrings.DEATH_PARAMETER);
        _playerController.RemoveListeners();

        Destroy(this);
    }

    #region Getters
    public Animator GetPlayerAnimator() => _playerAnimator;
    public CharacterController GetCharacterController() => _characterController;
    #endregion
}
