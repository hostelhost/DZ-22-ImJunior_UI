using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthSmoothSliderDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _smoothSlider;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _delayTime = 0.05f;

    private int _maximumLifeForce;
    private WaitForSeconds _waitForSeconds;
    private Coroutine _coroutine;

    private void Start()
    {
        Initialization();
    }

    private void OnEnable()
    {
        _health.HealthHasChanged += StartSmoothSlide;
    }

    private void OnDisable()
    {
        _health.HealthHasChanged -= StartSmoothSlide;
    }

    private void Initialization()
    {
        _maximumLifeForce = _health.GetMaximumLifeForce();
        _smoothSlider.maxValue = _maximumLifeForce;
        _smoothSlider.value = _maximumLifeForce;
        _waitForSeconds = new WaitForSeconds(_delayTime);
    }
    private void StartSmoothSlide()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Print());
    }

    private IEnumerator Print()
    {
        while (_smoothSlider.value != _health.LifeForce)
        {
            _smoothSlider.value = Mathf.MoveTowards(_smoothSlider.value, _health.LifeForce, _speed);
            yield return _waitForSeconds;
        }
    }
}
