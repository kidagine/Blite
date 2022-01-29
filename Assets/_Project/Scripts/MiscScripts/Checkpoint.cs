using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	private Animator _animator;

	private void Start()
	{
		_animator = GetComponent<Animator>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Player player))
		{
			_animator.Play("Checkpoint");
			SceneSettings.checkpointPosition = new Vector2(transform.position.x, transform.position.y - 1.0f);
		}
	}
}
