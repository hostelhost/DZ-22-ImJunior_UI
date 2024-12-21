using UnityEngine;
using UnityEngine.UI;

public class HealthSliderDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;

    private int _maximumLifeForce;

    private void Start()
    {
        Initialization();
    }

    private void OnEnable()
    {
        _health.HealthHasChanged += Print;
    }

    private void OnDisable()
    {
        _health.HealthHasChanged -= Print;
    }

    private void Initialization()
    {
        _maximumLifeForce = _health.GetMaximumLifeForce();
        _slider.maxValue = _maximumLifeForce;
        _slider.value = _maximumLifeForce;
    }

    private void Print()
    {
        _slider.value = _health.LifeForce;
    }
}
