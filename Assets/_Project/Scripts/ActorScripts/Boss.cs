using Demonics.Sounds;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
	[SerializeField] private Door _endDoor = default;
	[SerializeField] private GameObject _endBox = default;
	[SerializeField] private Animator _animator = default;
	[SerializeField] private Slider _healthSlider = default;
	[SerializeField] private GameObject _bossUI = default;
	[SerializeField] private GameObject _projectilePrefab = default;
	[SerializeField] private GameObject _projectileSquare = default;
	[SerializeField] private GameObject _projectileBeam = default;
	[SerializeField] private Transform[] _teleportPoints = default;
	[SerializeField] private Transform _squareTeleportPoint = default;
	[SerializeField] private Transform _beamTeleportPoint = default;
	private Rigidbody2D _rigidbody;
	private Audio _audio;
	private int _health = 15;
	private int _cachedTeleportIndex;
	private float _attackWaitTime;
	private bool _isHurt;
	private bool _squareAttack;
	private bool _canTeleport = true;

	private void Start()
	{
		_audio = GetComponent<Audio>();
		_rigidbody = GetComponent<Rigidbody2D>();
		StartCoroutine(TeleportCoroutine());
		StartCoroutine(AttackCoroutine());
	}

	IEnumerator TeleportCoroutine()
	{
		while (_canTeleport)
		{
			yield return new WaitForSeconds(3.0f);
			if (gameObject.activeSelf)
			{
				int changeAttackPosition = Random.Range(0, 5);
				if (changeAttackPosition == 1)
				{
					_squareAttack = true;
					transform.position = _squareTeleportPoint.position;
				}
				else if (changeAttackPosition == 2)
				{
					transform.position = _beamTeleportPoint.position;
					_canTeleport = false;
				}
				else
				{
					int randomTeleportIndex = Random.Range(0, _teleportPoints.Length);
					if (randomTeleportIndex == _cachedTeleportIndex)
					{
						if (randomTeleportIndex == _teleportPoints.Length - 1)
						{
							randomTeleportIndex = 0;
						}
						else
						{
							randomTeleportIndex++;
						}
					}
					transform.position = _teleportPoints[randomTeleportIndex].position;
					_cachedTeleportIndex = randomTeleportIndex;
				}
			}
		}
	}

	IEnumerator AttackCoroutine()
	{
		yield return new WaitForSeconds(1.0f);
		while (true)
		{
			yield return new WaitForSeconds(_attackWaitTime);
			if (gameObject.activeSelf)
			{
				if (_squareAttack)
				{
					_attackWaitTime = 1.5f;
					Instantiate(_projectileSquare, transform.position, Quaternion.identity);
					_squareAttack = false;
				}
				else
				{
					if (_canTeleport)
					{
						_attackWaitTime = 1.0f;
					}
					else
					{
						_attackWaitTime = 0.25f;
					}
					Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
				}
			}
		}
	}

	private void Update()
	{
		if (!_isHurt && _canTeleport)
		{
			_rigidbody.velocity = Vector2.zero;
		}
		else if (!_canTeleport)
		{
			_rigidbody.MovePosition(_rigidbody.position + Vector2.right * 2 * Time.fixedDeltaTime);
		}
	}

	public void LoseHealth(Vector2 direction)
	{
		_audio.Sound("Hurt").Play();
		_animator.SetTrigger("Hurt");
		_health--;
		if (_health <= 0)
		{
			_bossUI.gameObject.SetActive(false);
			_endDoor.Unlock();
			_endBox.SetActive(true);
			gameObject.SetActive(false);
		}
		_isHurt = true;
		_healthSlider.value = _health;
		Knockback(direction);
	}

	public void Knockback(Vector2 direction = default)
	{
		if (gameObject.activeSelf)
		{
			_rigidbody.velocity = direction * 10;
			StartCoroutine(ResetVelocityCoroutine());
		}
	}

	IEnumerator ResetVelocityCoroutine()
	{
		yield return new WaitForSeconds(0.1f);
		_rigidbody.velocity = Vector2.zero;
		_isHurt = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out BossStop bossStop))
		{
			_canTeleport = true;
			StartCoroutine(TeleportCoroutine());
		}
	}
}
