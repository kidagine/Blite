using UnityEngine;

public class Destructable : MonoBehaviour
{
	[SerializeField] private GameObject _explosionPrefab = default;


	public void Destruct()
	{
		Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
		gameObject.SetActive(false);
	}
}
