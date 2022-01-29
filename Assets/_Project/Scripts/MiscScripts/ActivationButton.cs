using Demonics.Sounds;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationButton : MonoBehaviour
{
	[SerializeField] private Sprite _activeButtonSprite = default;
	[SerializeField] private Sprite _inactiveButtonSprite = default;
	private SpriteRenderer _spriteRenderer;
	private Audio _audio;
	private bool _hasActivated;


	private void Start()
	{
		_audio = GetComponent<Audio>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!_hasActivated)
		{
			if (collision.TryGetComponent(out Projectile projectile))
			{
				_hasActivated = true;
				_audio.Sound("ButtonActivate").Play();
				_spriteRenderer.sprite = _inactiveButtonSprite;
			}
		}
	}
}
