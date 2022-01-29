using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] private GameObject _explosionPrefab = default;
	private Rigidbody2D _rigidbody;
	private Vector2 _direction;
	private float _movementSpeed = 5.0f;


	void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_direction = transform.up;
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
				}
			}
		}
		else if (collision.TryGetComponent(out SwordAttack swordAttack))
		{
			if (BliteManager.Instance.IsWorldBlack)
			{
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
