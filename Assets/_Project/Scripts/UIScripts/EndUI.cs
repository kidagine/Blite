using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndUI : MonoBehaviour
{
	[SerializeField] private GameObject _credits = default;
	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	public void Credits()
	{
		_credits.gameObject.SetActive(true);
		gameObject.SetActive(false);
	}
}
