using UnityEngine;

public class HitBox : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Player player))
		{
			player.LoseHealth();
		}
	}
}
