using Cinemachine;
using UnityEngine;

public class Door : MonoBehaviour
{
	[SerializeField] Transform _enterPoint = default;
	[SerializeField] private bool _isHorizontal = default;
	[SerializeField] private CinemachineVirtualCamera _horizontalCamera = default;
	[SerializeField] private CinemachineVirtualCamera _verticalCamera = default;


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Player player))
		{
			if (_isHorizontal)
			{
				_verticalCamera.gameObject.SetActive(false);
				_horizontalCamera.gameObject.SetActive(true);
			}
			else
			{
				_horizontalCamera.gameObject.SetActive(false);
				_verticalCamera.gameObject.SetActive(true);
			}
			player.transform.position = _enterPoint.position;
		}
	}
}
