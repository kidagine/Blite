using UnityEngine;

public class SwordAttack : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Destructable destructable))
		{
			destructable.Destruct();
		}
	}
}