using UnityEngine;

public class BliteCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    void Update()
    {
        transform.position = _player.transform.position;
    }
}
