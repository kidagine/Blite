using UnityEngine;

public class SwordAttack : MonoBehaviour
{
	private PlayerMovement _playerMovement;


	private void Start()
	{
		_playerMovement = transform.root.GetComponent<PlayerMovement>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Destructable destructable))
		{
			destructable.Destruct();
		}
		if (collision.TryGetComponent(out Boss boss))
		{
			boss.LoseHealth(_playerMovement.CachedMoveDirection);
		}
	}
}