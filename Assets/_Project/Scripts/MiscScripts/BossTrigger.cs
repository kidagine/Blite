using Demonics.Sounds;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class BossTrigger : MonoBehaviour
{
	[SerializeField] private Boss _boss = default;
	[SerializeField] private GameObject _bossUI = default;
	[SerializeField] private Audio _audio = default;
	[SerializeField] private GameObject _bossCamera = default;
	[SerializeField] private PixelPerfectCamera _pixelPerfectCamera = default;



	private void OnTriggerEnter2D(Collider2D collision)
	{
		_bossCamera.SetActive(true);
		_pixelPerfectCamera.assetsPPU = 12;
		MusicSingleton.Instance.GetComponent<Audio>().Sound("Music").Stop();
		_audio.Sound("Boss").Play();
		_bossUI.gameObject.SetActive(true);
		_boss.gameObject.SetActive(true);	
		gameObject.SetActive(false);
	}
}
