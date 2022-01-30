using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
	private Animator _animator;


	void Start()
	{
		_animator = GetComponent<Animator>();
	}

	public void SetMovement(Vector2 movementDirection)
	{
		_animator.SetFloat("MovementInputX", movementDirection.x);
		_animator.SetFloat("MovementInputY", movementDirection.y);
	}

	public void Dodge()
	{
		_animator.SetTrigger("Dodge");
	}

	public void Attack()
	{
		_animator.SetTrigger("Attack");
	}

	public void IsMoving(bool state)
	{
		_animator.SetBool("IsMoving", state);
	}

	public void Hurt()
	{
		_animator.SetTrigger("Hurt");
	}
}
