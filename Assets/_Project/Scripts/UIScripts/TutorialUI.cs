using System.Collections;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _tutorialText = default;
	private Coroutine _coroutine;

	public void ShowTutorial(string text, float time)
	{
		_tutorialText.text = text;
		gameObject.SetActive(true);
		if (_coroutine != null)
		{
			StopCoroutine(_coroutine);
		}
		_coroutine = StartCoroutine(ShowTutorialCoroutine(time));
	}

	IEnumerator ShowTutorialCoroutine(float time)
	{
		yield return new WaitForSeconds(time);
		gameObject.SetActive(false);
	}
}
