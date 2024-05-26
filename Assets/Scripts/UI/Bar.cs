using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void SetMaxValue(float maxValue)
    {
        slider.maxValue = maxValue;
        slider.value = maxValue;
    }

    public void UpdateSliderValue(float value)
    {
        if (value <= 0)
        {
            slider.value = 0;
        }
        else
        {
            slider.value = value;
        }
    }
}
