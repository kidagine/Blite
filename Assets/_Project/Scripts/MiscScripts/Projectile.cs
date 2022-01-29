using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] private GameObject _explosionPrefab = default;

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
		else
		{
			Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
			gameObject.SetActive(false);
		}
	}
}
