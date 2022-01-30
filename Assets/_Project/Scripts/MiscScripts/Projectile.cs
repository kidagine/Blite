using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] private GameObject _explosionPrefab = default;
	[SerializeField] private Vector2 _directionGoTo = default;
	[SerializeField] private bool _hardCodedDirection = default;
	private Rigidbody2D _rigidbody;
	private Vector2 _direction;
	private float _movementSpeed = 5.0f;
	private bool _isReflected;

	void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		if (_hardCodedDirection)
		{
			_direction = _directionGoTo;
		}
		else
		{
			_direction = transform.up;
		}
	}

	void FixedUpdate()
	{
		_rigidbody.MovePosition(_rigidbody.position + _direction * _movementSpeed * Time.fixedDeltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Player player))
		{
			if (collision.TryGetComponent(out PlayerMovement playerMovement))
			{
				if (!playerMovement.IsDodging || BliteManager.Instance.IsWorldBlack)
				{
					player.LoseHealth();
					Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
					gameObject.SetActive(false);
				}
			}
		}
		else if (collision.TryGetComponent(out Boss boss))
		{
			if (_isReflected)
			{
				Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
				boss.LoseHealth(transform.up * -1.0f);
				gameObject.SetActive(false);
			}
		}
		else if (collision.TryGetComponent(out SwordAttack swordAttack))
		{
			if (BliteManager.Instance.IsWorldBlack)
			{
				_isReflected = true;
				Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
				_movementSpeed += 4;
				_direction = swordAttack.transform.root.GetComponent<PlayerMovement>().CachedMoveDirection;
			}
		}
		else if (!collision.TryGetComponent(out ProjectileSpawner projectileSpawner))
		{
			Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
			gameObject.SetActive(false);
		}
	}
}
