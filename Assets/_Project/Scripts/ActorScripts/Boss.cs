using Demonics.Sounds;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
	[SerializeField] private Door _endDoor = default;
	[SerializeField] private GameObject _endBox = default;
	[SerializeField] private Animator _animator = default;
	[SerializeField] private Slider _healthSlider = default;
	private Rigidbody2D _rigidbody;
	private Audio _audio;
	private int _health = 15;

	private void Start()
	{
		_audio = GetComponent<Audio>();
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	public void LoseHealth(Vector2 direction)
	{
		_audio.Sound("Hurt").Play();
		_animator.SetTrigger("Hurt");
		_health--;
		if (_health <= 0)
		{
			_endDoor.Unlock();
			_endBox.SetActive(true);
		}
		_healthSlider.value = _health;
		Knockback(direction);
	}

	public void Knockback(Vector2 direction = default)
	{
		_rigidbody.velocity = direction * 10;
		StartCoroutine(ResetVelocityCoroutine());
	}

	IEnumerator ResetVelocityCoroutine()
	{
		yield return new WaitForSeconds(0.1f);
		_rigidbody.velocity = Vector2.zero;
	}
}
