using Demonics.Manager;
using Demonics.Sounds;
using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class BliteManager : Singleton<BliteManager>
{
	public float BliteDistance = 0.0f;
	private readonly float _maxBliteDistance = 18.0f;
	private readonly float _minBliteDistance = 0.0f;
	private Audio _audio;
	public bool IsWorldBlack { get; set; } = true;
	public bool IsWorldChanging { get; private set; }


	void Start()
	{
		_audio = GetComponent<Audio>();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	public void SwapWorlds()
	{
		StartCoroutine(SwapWorldsCoroutine());
	}

	public void SwapToWhiteWorld()
	{
		BliteDistance = 0.0f;
		IsWorldBlack = true;
	}

	IEnumerator SwapWorldsCoroutine()
	{
		IsWorldChanging = true;
		float elapsedTime = 0.0f;
		float waitTime = 0.5f;
		float startValue = BliteDistance;
		if (IsWorldBlack)
		{
			_audio.Sound("WorldBlack").Play();
		}
		else
		{
			_audio.Sound("WorldWhite").Play();
		}
		float endValue = IsWorldBlack ? _maxBliteDistance : _minBliteDistance;
		IsWorldBlack = !IsWorldBlack;
		while (elapsedTime < waitTime)
		{
			BliteDistance = Mathf.Lerp(startValue, endValue, (elapsedTime / waitTime));
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		BliteDistance = endValue;
		IsWorldChanging = false;
		yield return null;
	}
}
