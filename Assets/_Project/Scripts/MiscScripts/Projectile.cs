using UnityEngine;

public class Projectile : MonoBehaviour
{
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
			gameObject.SetActive(false);
		}
	}
}
