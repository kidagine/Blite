using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private GameObject _explosionPrefab;
	private Rigidbody2D _rigidbody;
	private SpriteRenderer _spriteRenderer;
	private readonly float _movementChangeCoolDown = 1.2f;
	private readonly int _knockbackForce = 10;
	[SerializeField] private int _walkSpeed = 2;
	private float _currentMovementChangeCoolDown;
	private bool _isFrozen;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
		if (_walkSpeed < 0)
		{
			_spriteRenderer.flipX = true;
		}
	}

	void Update()
	{
		if (!_isFrozen)
		{
			_currentMovementChangeCoolDown -= Time.deltaTime;
			if (_currentMovementChangeCoolDown <= 0)
			{
				ChangeMovementDirection();
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.TryGetComponent(out Player player))
		{
			player.LoseHealth();
		}
		else
		{
			ChangeMovementDirection();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out SwordAttack swordAttack))
		{
			Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
			gameObject.SetActive(false);
		}
	}

	private void ChangeMovementDirection()
	{
		_walkSpeed *= -1;
		_spriteRenderer.flipX = !_spriteRenderer.flipX;
		_rigidbody.velocity = Vector2.right * _walkSpeed;
		_currentMovementChangeCoolDown = _movementChangeCoolDown;
	}
}
