using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Slider _bliteSlider = default;


    public void SetBlite(float value)
    {
        _bliteSlider.value = value;
    }
}
