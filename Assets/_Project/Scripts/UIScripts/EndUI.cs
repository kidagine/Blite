using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndUI : MonoBehaviour
{
	[SerializeField] private GameObject _credits = default;
	public void Credits()
	{
		_credits.gameObject.SetActive(true);
		gameObject.SetActive(false);
	}
}
