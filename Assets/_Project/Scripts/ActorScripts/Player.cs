using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private PlayerUI _playerUI = default;
	[SerializeField] private PlayerAnimator _playerAnimator = default;
	private float _blite;
	public bool IsAttacking { get; private set; }


	private void Start()
	{
		_blite = 1.0f;
		_playerUI.SetBlite(_blite);
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
			IsAttacking = true;
			_playerAnimator.Attack();
		}
	}

	public void StopAttack()
	{
		IsAttacking = false;
	}
}
