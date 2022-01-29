using Demonics.Manager;
using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class BliteManager : Singleton<BliteManager>
{
	public float BliteDistance = 0.0f;
	private bool _isWorldBlack = true;
	private readonly float _maxBliteDistance = 12.0f;
	private readonly float _minBliteDistance = 0.0f;
	public bool IsWorldChanging { get; private set; }
	public void SwapWorlds()
	{
		StartCoroutine(SwapWorldsCoroutine());
	}

	IEnumerator SwapWorldsCoroutine()
	{
		IsWorldChanging = true;
		float elapsedTime = 0.0f;
		float waitTime = 0.5f;
		float startValue = BliteDistance;
		float endValue = _isWorldBlack ? _maxBliteDistance : _minBliteDistance;
		while (elapsedTime < waitTime)
		{
			BliteDistance = Mathf.Lerp(startValue, endValue, (elapsedTime / waitTime));
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		BliteDistance = endValue;
		_isWorldBlack = !_isWorldBlack;
		IsWorldChanging = false;
		yield return null;
	}
}
