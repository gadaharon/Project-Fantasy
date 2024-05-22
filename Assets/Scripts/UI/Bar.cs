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
    }

    public void UpdateSLiderValue(float value)
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
