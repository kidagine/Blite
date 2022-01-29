using UnityEngine;

public class BliteCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    void Update()
    {
        if (_player != null)
        transform.position = _player.transform.position;
    }
}
