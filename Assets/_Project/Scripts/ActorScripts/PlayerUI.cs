using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
	[SerializeField] private Slider _bliteSlider = default;
	[SerializeField] private Image[] _hearts = default;

	public void SetBlite(float value)
	{
		_bliteSlider.value = value;
	}

	public void SetHealth(int value)
	{
		for (int i = 0; i < _hearts.Length; i++)
		{
			_hearts[i].gameObject.SetActive(false);
		}
		for (int i = 0; i < value; i++)
		{
			_hearts[i].gameObject.SetActive(true);
		}
	}
}
