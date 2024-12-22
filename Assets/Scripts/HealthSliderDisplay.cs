using UnityEngine;
using UnityEngine.UI;

public class HealthSliderDisplay : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void Initialization(int maximumLifeForce)
    {
        _slider.maxValue = maximumLifeForce;
        _slider.value = maximumLifeForce;
    }

    public void Print(int lifeForce)
    {
        _slider.value = lifeForce;
    }
}
