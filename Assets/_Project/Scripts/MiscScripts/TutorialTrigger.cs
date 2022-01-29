using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
	[SerializeField] private TutorialUI _tutorialUI = default;
	[SerializeField] private string _tutorialText = default;
	[SerializeField] private float _time = 5.0f;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Player player))
		{
			_tutorialUI.ShowTutorial(_tutorialText, _time);
			gameObject.SetActive(false);
		}
	}
}
