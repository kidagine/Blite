using Demonics.Sounds;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private PlayerUI _playerUI = default;
	[SerializeField] private PlayerAnimator _playerAnimator = default;
	[SerializeField] private GameObject _explosionPrefab = default;
	private PlayerMovement _playerMovement;
	private Audio _audio;
	private float _blite;
	private int _health = 3;
	private bool _invisibility;
	public bool IsAttacking { get; private set; }
	public bool IsHurt { get; set; }


	private void Start()
	{
		_blite = 1.0f;
		_playerUI.SetBlite(_blite);
		_audio = GetComponent<Audio>();
		_playerMovement = GetComponent<PlayerMovement>();
		if (SceneSettings.checkpointPosition != default)
		{
			transform.position = SceneSettings.checkpointPosition;
		}
	}

	void Update()
	{
		RechargeBlite();
	}

	public void BliteAction()
	{
		if (Input.GetKeyDown(KeyCode.R) && _blite >= 1.0f)
		{
			_blite = 0.0f;
			_playerUI.SetBlite(_blite);
			BliteManager.Instance.SwapWorlds();
		}
	}

	private void RechargeBlite()
	{
		if (_blite < 1.0f && !BliteManager.Instance.IsWorldChanging)
		{
			_blite += Time.deltaTime;
			_playerUI.SetBlite(_blite);
		}
	}

	public void AttackAction()
	{
		if (!IsAttacking)
		{
			_audio.Sound("Attack").Play();
			IsAttacking = true;
			_playerAnimator.Attack();
		}
	}

	public void StopAttack()
	{
		IsAttacking = false;
	}

	public void LoseHealth()
	{
		if (!IsHurt && !_invisibility)
		{
			_audio.Sound("Hurt").Play();
			_playerAnimator.Hurt();
			_health--;
			_playerUI.SetHealth(_health);
			if (_health <= 0)
			{
				Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
				BliteManager.Instance.ResetGame();
				Destroy(gameObject);
			}
			IsHurt = true;
			StartCoroutine(InvisibilityCoroutine());
			_playerMovement.Knockback();
		}
	}

	IEnumerator InvisibilityCoroutine()
	{
		_invisibility = true;
		yield return new WaitForSeconds(0.15f); ;
		_invisibility = false;
	}
}
