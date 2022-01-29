using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private PlayerAnimator _playerAnimator = default;
	private Player _player;
	private Rigidbody2D _rigidbody;
	private Vector2 _inputDirection;
	private Vector2 _cachedMoveDirection = Vector2.down;
	private float _maximumAngle = 0.0f;
	private float _minimumAngle = 0.0f;
	private float _movementSpeed = 3.0f;
	private bool _isDodging;
	public Vector2 InputDirection { get; set; }


	void Start()
	{
		_player = GetComponent<Player>();
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		MovementDirection();
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
			Debug.Log(InputDirection);
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
		if (!_isDodging && !_player.IsAttacking)
		{
			_rigidbody.MovePosition(_rigidbody.position + _inputDirection * _movementSpeed * Time.fixedDeltaTime);
		}
	}

	public void DodgeAction()
	{
		if (!_isDodging)
		{
			_playerAnimator.Dodge();
			_rigidbody.velocity = _cachedMoveDirection * 8.0f;
			_isDodging = true;
		}
	}

	public void StopDodge()
	{
		_rigidbody.velocity = Vector2.zero;
		_isDodging = false;
	}
}
