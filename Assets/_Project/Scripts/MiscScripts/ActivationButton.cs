using Demonics.Sounds;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivationButton : MonoBehaviour
{
	[SerializeField] private UnityEvent _onActivate = default;
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
				_onActivate?.Invoke();
				_hasActivated = true;
				_audio.Sound("ButtonActivate").Play();
				_spriteRenderer.sprite = _inactiveButtonSprite;
			}
		}
	}
}
