using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement = default;
    [SerializeField] private Player _player = default;


    public void StopDodgeAnimationEvent()
    {
        _playerMovement.StopDodge();
    }

    public void StopAttackAnimationEvent()
    {
        _player.StopAttack();
    }
}
