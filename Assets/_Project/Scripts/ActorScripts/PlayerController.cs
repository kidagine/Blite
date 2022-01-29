using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private PlayerMovement _playerMovement;
	private Player _player;


	void Start()
	{
		_player = GetComponent<Player>();
		_playerMovement = GetComponent<PlayerMovement>();
	}

	void Update()
	{
		SetMovementInput();
		Dodge();
		Attack();
		Blite();
	}

	private void SetMovementInput()
	{
		Vector2 inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		_playerMovement.InputDirection = inputDirection;
	}

	private void Dodge()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			_playerMovement.DodgeAction();
		}
	}

	private void Attack()
	{
		if (Input.GetKeyDown(KeyCode.J))
		{
			_player.AttackAction();
		}
	}

	private void Blite()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			_player.BliteAction();
		}
	}
}
