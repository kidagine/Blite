using UnityEngine;

public class Door : MonoBehaviour
{
	[SerializeField] GameObject _exitPointCamera = default;
	[SerializeField] GameObject _enterPointCamera = default;


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out Player player))
		{
			player.transform.position = transform.GetChild(0).position;
			//_enterPointCamera.gameObject.SetActive(false);
			//_exitPointCamera.gameObject.SetActive(true);
		}
	}
}
