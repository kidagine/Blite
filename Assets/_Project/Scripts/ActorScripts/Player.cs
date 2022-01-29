using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private PlayerUI _playerUI = default;
	private float _blite;


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
}
