using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement = default;


    public void StopDodgeAnimationEvent()
    {
        _playerMovement.StopDodge();
    }
}
