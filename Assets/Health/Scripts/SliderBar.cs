using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    public void SetMax(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetCurrent(float health)
    {
        slider.value = health;
    }
}
