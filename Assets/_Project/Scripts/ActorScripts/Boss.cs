using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
	[SerializeField] private Door _endDoor = default;
	[SerializeField] private GameObject _endBox = default;
	private int _health = 2;
	public void LoseHealth()
	{
		_health--;
		if (_health <= 0)
		{
			_endDoor.Unlock();
			_endBox.SetActive(true);
		}
	}
}
