using Demonics.Sounds;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
	[SerializeField] private Boss _boss = default;
	[SerializeField] private GameObject _bossUI = default;
	[SerializeField] private Audio _audio = default;


	private void OnTriggerEnter2D(Collider2D collision)
	{
		_audio.Sound("Music").Stop();
		_audio.Sound("Boss").Play();
		_bossUI.gameObject.SetActive(true);
		_boss.gameObject.SetActive(true);	
		gameObject.SetActive(false);
	}
}
