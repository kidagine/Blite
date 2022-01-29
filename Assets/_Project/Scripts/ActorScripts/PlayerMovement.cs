using Demonics.Sounds;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private PlayerAnimator _playerAnimator = default;
	private Player _player;
	private Rigidbody2D _rigidbody;
	private Audio _audio;
	private Vector2 _inputDirection;
	private Vector2 _cachedMoveDirection = Vector2.down;
	private readonly float _currentFootstepSpeed = 0.3f;
	private readonly float _movementSpeed = 4.0f;
	private readonly float _dodgeForce = 11.0f;
	private float _footstepCooldown;
	public Vector2 InputDirection { get; set; }
	public bool IsDodging { get; private set; }

	void Start()
	{
		_player = GetComponent<Player>();
		_rigidbody = GetComponent<Rigidbody2D>();
		_audio = GetComponent<Audio>();
		_playerAnimator.SetMovement(_cachedMoveDirection);
	}

	void Update()
	{
		MovementDirection();
		Footsteps();
	}

	void FixedUpdate()
	{
		Movement();
	}

	private void MovementDirection()
	{
		if (InputDirection != Vector2.zero)
		{
			if (Mathf.Abs(InputDirection.x) == 1.0f && Mathf.Abs(InputDirection.y) == 1.0f)
			{
				InputDirection /= 1.33f;
			}
			_cachedMoveDirection = InputDirection;
			_inputDirection = InputDirection;
			_playerAnimator.SetMovement(_inputDirection);
			_playerAnimator.IsMoving(true);
		}
		else
		{
			_inputDirection = InputDirection;
			_playerAnimator.IsMoving(false);
		}
	}

	private void Movement()
	{
		if (!IsDodging & !_player.IsHurt && !_player.IsAttacking)
		{
			_rigidbody.MovePosition(_rigidbody.position + _inputDirection * _movementSpeed * Time.fixedDeltaTime);
		}
	}

	public void DodgeAction()
	{
		if (!IsDodging & !_player.IsHurt && !_player.IsAttacking)
		{
			_audio.Sound("Dodge").Play();
			_playerAnimator.Dodge();
			_rigidbody.velocity = _cachedMoveDirection * _dodgeForce;
			IsDodging = true;
		}
	}

	public void StopDodge()
	{
		_rigidbody.velocity = Vector2.zero;
		IsDodging = false;
	}

	public void Knockback(Vector2 direction = default)
	{
		_rigidbody.velocity = (_cachedMoveDirection * -1.0f) * 10;
		StartCoroutine(ResetVelocityCoroutine());
	}

	private void Footsteps()
	{
		if (InputDirection.magnitude > 0.0f)
		{
			_footstepCooldown -= Time.deltaTime;
			if (_footstepCooldown <= 0)
			{
				_audio.SoundGroup("Footsteps").PlayInRandom();
				_footstepCooldown = _currentFootstepSpeed;
			}
		}
	}

	IEnumerator ResetVelocityCoroutine()
	{
		yield return new WaitForSeconds(0.1f);
		_player.IsHurt = false;
		_rigidbody.velocity = Vector2.zero;
	}
}
