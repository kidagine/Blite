using UnityEngine;

public class MoveForward : MonoBehaviour
{
	private Rigidbody2D _rigidbody;
	private float _movementSpeed = 5.0f;


	void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();   
	}

	void FixedUpdate()
	{
		_rigidbody.MovePosition(_rigidbody.position + new Vector2(transform.right.x, transform.right.y) * _movementSpeed * Time.fixedDeltaTime);
	}
}
